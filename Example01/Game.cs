using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Media;
using System.Runtime.InteropServices; // [1] THÊM THƯ VIỆN NÀY
using System.Text;                    // [1] THÊM THƯ VIỆN NÀY

namespace Example01
{
    public partial class Game : Form
    {
        // --- CẤU HÌNH GAME ---
        int playerSpeed = 12;
        int bulletSpeed = 17;
        int enemySpeed = 3;
        int enemyBulletSpeed = 10;
        int score = 0;
        int highScore = 0;
        int level = 1;
        int playerHealth = 3;
        int maxHealth = 5;
        int bossHealth = 20;
        int enemyShootChance = 1;

        SoundPlayer sfxShoot;

        int bulletLevel = 1;
        int maxBulletLevel = 3;
        int itemSpeed = 5;

        bool isGameOver = false;

        // --- BIẾN CHO HIỆU ỨNG TRANSITION (RANDOM BARS) ---
        bool isTransitioning = false;
        List<Panel> transitionBars = new List<Panel>();
        int transitionStep = 0;
        int transitionWaitTime = 0;
        bool isCovering = true;

        Random rnd = new Random();

        // --- BỘ NHỚ ĐỆM ẢNH ---
        Dictionary<string, Image> imageCache = new Dictionary<string, Image>();

        // --- DANH SÁCH QUẢN LÝ ---
        List<PictureBox> bullets = new List<PictureBox>();
        List<PictureBox> enemyBullets = new List<PictureBox>();
        List<PictureBox> enemies = new List<PictureBox>();
        List<PictureBox> items = new List<PictureBox>();
        List<Label> effects = new List<Label>();

        // --- GIAO DIỆN ---
        PictureBox pbPlayer = new PictureBox();
        Label lblHealth = new Label();
        Label lblHighScore = new Label();
        Label lblLevelMsg = new Label();

        // Điều khiển
        bool goLeft, goRight, goUp, goDown;

        // --- TIMER ---
        System.Windows.Forms.Timer timerPowerUp = new System.Windows.Forms.Timer();
        System.Windows.Forms.Timer timerTransition = new System.Windows.Forms.Timer();

        // [2] KHAI BÁO HÀM PHÁT NHẠC TỪ WINDOWS
        [DllImport("winmm.dll")]
        private static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hwndCallback);

        public Game()
        {
            InitializeComponent();

            // Tối ưu hóa render
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            this.UpdateStyles();

            // Kết nối bàn phím
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyUp += new KeyEventHandler(Form1_KeyUp);

            // Cấu hình Timer
            timerPowerUp.Interval = 5000;
            timerPowerUp.Tick += TimerPowerUp_Tick;

            timerTransition.Interval = 20;
            timerTransition.Tick += TimerTransition_Tick;

            SetupGame();
        }

        // [3] HÀM XỬ LÝ NHẠC NỀN
        private void PlayBackgroundMusic(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // Đóng nhạc cũ nếu đang chạy để tránh lỗi
                    mciSendString("close BgMusic", null, 0, IntPtr.Zero);

                    // Mở file mới và đặt tên là BgMusic
                    string command = "open \"" + filePath + "\" type mpegvideo alias BgMusic";
                    mciSendString(command, null, 0, IntPtr.Zero);

                    // Phát lặp lại (repeat)
                    mciSendString("play BgMusic repeat", null, 0, IntPtr.Zero);
                }
            }
            catch { }
        }

        private void StopBackgroundMusic()
        {
            try
            {
                mciSendString("close BgMusic", null, 0, IntPtr.Zero);
            }
            catch { }
        }

        private void TimerPowerUp_Tick(object sender, EventArgs e)
        {
            if (bulletLevel > 1)
            {
                bulletLevel = 1;
                ShowFloatingText("POWER LOST", Color.Gray, pbPlayer.Left, pbPlayer.Top - 30);
            }
            timerPowerUp.Stop();
        }

        // --- XỬ LÝ HIỆU ỨNG RANDOM BARS ---
        private void TimerTransition_Tick(object sender, EventArgs e)
        {
            if (isCovering)
            {
                for (int k = 0; k < 2; k++)
                {
                    if (transitionStep < transitionBars.Count)
                    {
                        transitionBars[transitionStep].Visible = true;
                        transitionBars[transitionStep].BringToFront();
                        transitionStep++;
                    }
                }

                if (transitionStep >= transitionBars.Count)
                {
                    lblLevelMsg.Text = "LEVEL " + (level + 1);
                    lblLevelMsg.Visible = true;
                    lblLevelMsg.BringToFront();

                    level++;
                    UpdateScoreBoard();
                    this.SuspendLayout();
                    SetupLevel();
                    this.ResumeLayout();

                    isCovering = false;
                    transitionWaitTime = 40;
                }
            }
            else if (transitionWaitTime > 0)
            {
                transitionWaitTime--;
            }
            else
            {
                lblLevelMsg.Visible = false;
                for (int k = 0; k < 2; k++)
                {
                    if (transitionStep > 0)
                    {
                        transitionStep--;
                        transitionBars[transitionStep].Visible = false;
                    }
                }

                if (transitionStep <= 0)
                {
                    timerTransition.Stop();
                    isTransitioning = false;
                    gameTimer.Start();
                }
            }
        }

        private void InitializeTransitionBars()
        {
            if (transitionBars.Count > 0) return;
            int barCount = 20;
            int barWidth = this.ClientSize.Width / barCount;

            for (int i = 0; i < barCount; i++)
            {
                Panel p = new Panel();
                p.BackColor = Color.Black;
                p.Size = new Size(barWidth + 5, this.ClientSize.Height);
                p.Location = new Point(i * barWidth, 0);
                p.Visible = false;
                this.Controls.Add(p);
                transitionBars.Add(p);
            }
        }

        private void ShuffleBars()
        {
            int n = transitionBars.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Panel value = transitionBars[k];
                transitionBars[k] = transitionBars[n];
                transitionBars[n] = value;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }

        private void SetImage(PictureBox pb, string fileName, Color fallbackColor)
        {
            try
            {
                if (imageCache.ContainsKey(fileName))
                {
                    pb.Image = imageCache[fileName];
                }
                else
                {
                    if (File.Exists(fileName))
                    {
                        Image img = Image.FromFile(fileName);
                        imageCache.Add(fileName, img);
                        pb.Image = img;
                    }
                    else
                    {
                        pb.BackColor = fallbackColor;
                        return;
                    }
                }
                pb.SizeMode = PictureBoxSizeMode.Zoom;
                pb.BackColor = Color.Transparent;
            }
            catch
            {
                pb.BackColor = fallbackColor;
            }
        }

        private void ChangeBackground(string bgName)
        {
            try
            {
                if (imageCache.ContainsKey(bgName))
                    this.BackgroundImage = imageCache[bgName];
                else if (File.Exists(bgName))
                {
                    Image bg = Image.FromFile(bgName);
                    imageCache[bgName] = bg;
                    this.BackgroundImage = bg;
                }
            }
            catch { }
        }

        private void SetupGame()
        {
            this.Text = "Space Invaders: Galactic Defender - With Music";
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(800, 600);

            InitializeTransitionBars();
            ChangeBackground("vutru.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;

            if (!this.Controls.Contains(pbPlayer)) this.Controls.Add(pbPlayer);
            pbPlayer.Size = new Size(150, 170);
            pbPlayer.Left = this.ClientSize.Width / 2 - pbPlayer.Width / 2;
            pbPlayer.Top = this.ClientSize.Height - 200;

            if (File.Exists("player.png")) SetImage(pbPlayer, "player.png", Color.Lime);
            else SetImage(pbPlayer, "maybay.png", Color.Lime);

            pbPlayer.BringToFront();

            LoadHighScore();
            SetupUI();

            score = 0; level = 1; playerHealth = 3; bulletLevel = 1; isGameOver = false;
            isTransitioning = false;
            timerPowerUp.Stop();
            timerTransition.Stop();

            gameTimer.Interval = 20;
            gameTimer.Start();

            // [4] BẬT NHẠC NỀN
            PlayBackgroundMusic("nhacnen.mp3");

            UpdateScoreBoard();
            SetupLevel();

            try
            {
                if (File.Exists("lazesound.wav"))
                {
                    sfxShoot = new SoundPlayer("lazesound.wav");
                    sfxShoot.Load();
                }
            }
            catch { }
        }

        private void SetupUI()
        {
            Font retroFont = new Font("Consolas", 14, FontStyle.Bold);

            lblHealth.Font = retroFont; lblHealth.ForeColor = Color.White;
            lblHealth.Location = new Point(12, 40); lblHealth.AutoSize = true;
            lblHealth.BackColor = Color.Transparent;
            if (!this.Controls.Contains(lblHealth)) this.Controls.Add(lblHealth);
            lblHealth.BringToFront();

            lblHighScore.Font = retroFont; lblHighScore.ForeColor = Color.Yellow;
            lblHighScore.Location = new Point(this.ClientSize.Width - 250, 40); lblHighScore.AutoSize = true;
            lblHighScore.BackColor = Color.Transparent;
            if (!this.Controls.Contains(lblHighScore)) this.Controls.Add(lblHighScore);
            lblHighScore.BringToFront();

            lblLevelMsg.Font = new Font("Consolas", 36, FontStyle.Bold);
            lblLevelMsg.ForeColor = Color.Cyan;
            lblLevelMsg.AutoSize = false;
            lblLevelMsg.Size = new Size(800, 100);
            lblLevelMsg.TextAlign = ContentAlignment.MiddleCenter;
            lblLevelMsg.Location = new Point(0, this.ClientSize.Height / 2 - 50);
            lblLevelMsg.BackColor = Color.Transparent;
            lblLevelMsg.Visible = false;
            if (!this.Controls.Contains(lblLevelMsg)) this.Controls.Add(lblLevelMsg);
        }

        private void SetupLevel()
        {
            ClearGameObjects();
            enemyShootChance = 1 + (level / 2);

            if (level <= 3) ChangeBackground("vutru.png");
            else if (level <= 6) ChangeBackground("vutru2.png");
            else ChangeBackground("vutru3.png");

            if (level % 5 == 0)
            {
                enemySpeed = 3 + level;
                bossHealth = 20 + (level * 5);
                CreateBoss();
            }
            else
            {
                int rows = Math.Min(3 + (level / 2), 5);
                int cols = Math.Min(6 + (level / 2), 9);
                enemySpeed = 3 + (level / 3);
                CreateEnemies(rows, cols);
            }
        }

        private void ClearGameObjects()
        {
            foreach (var x in enemies) x.Visible = false;
            foreach (var x in bullets) x.Visible = false;
            foreach (var x in enemyBullets) x.Visible = false;
            foreach (var x in items) x.Visible = false;
            foreach (var x in effects) x.Visible = false;

            foreach (var x in enemies) this.Controls.Remove(x); enemies.Clear();
            foreach (var x in bullets) this.Controls.Remove(x); bullets.Clear();
            foreach (var x in enemyBullets) this.Controls.Remove(x); enemyBullets.Clear();
            foreach (var x in items) this.Controls.Remove(x); items.Clear();
            foreach (var x in effects) this.Controls.Remove(x); effects.Clear();
        }

        private void CreateEnemies(int rows, int cols)
        {
            int startX = (this.ClientSize.Width - (cols * 60)) / 2;
            int startY = 80;

            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    PictureBox enemy = new PictureBox();
                    enemy.Size = new Size(50, 50);
                    if (j % 2 == 0) SetImage(enemy, "enemy_purple.png", Color.Purple);
                    else SetImage(enemy, "nhen-removebg-preview.png", Color.Red);

                    enemy.Tag = "enemy";
                    enemy.Left = startX + i * 60;
                    enemy.Top = startY + j * 60;
                    this.Controls.Add(enemy);
                    enemies.Add(enemy);
                }
            }
        }

        private void CreateBoss()
        {
            PictureBox boss = new PictureBox();
            boss.Size = new Size(200, 120);
            SetImage(boss, "Dragon.png", Color.DarkMagenta);
            boss.Tag = "boss";
            boss.Left = this.ClientSize.Width / 2 - 100;
            boss.Top = 80;
            this.Controls.Add(boss);
            enemies.Add(boss);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (isGameOver || isTransitioning) return;

            if (goLeft && pbPlayer.Left > 10) pbPlayer.Left -= playerSpeed;
            if (goRight && pbPlayer.Left < this.ClientSize.Width - pbPlayer.Width - 10) pbPlayer.Left += playerSpeed;
            if (goUp && pbPlayer.Top > 10) pbPlayer.Top -= playerSpeed;
            if (goDown && pbPlayer.Top < this.ClientSize.Height - pbPlayer.Height - 10) pbPlayer.Top += playerSpeed;

            MoveEnemies();
            EnemyAttackLogic();
            HandlePlayerBullets();
            HandleEnemyBullets();
            HandleItems();
            HandleEffects();

            if (enemies.Count == 0) StartLevelTransition();

            UpdateScoreBoard();
        }

        private void StartLevelTransition()
        {
            isTransitioning = true;
            gameTimer.Stop();
            ShuffleBars();
            transitionStep = 0;
            isCovering = true;
            transitionWaitTime = 0;
            foreach (var p in transitionBars) p.Visible = false;
            timerTransition.Start();
        }

        private void SpawnItem(int x, int y)
        {
            if (rnd.Next(0, 100) < 5)
            {
                PictureBox item = new PictureBox();
                item.Size = new Size(30, 30);
                if (rnd.Next(0, 2) == 0) { SetImage(item, "item_heart.png", Color.HotPink); item.Tag = "item_heart"; }
                else { SetImage(item, "item_power.png", Color.Cyan); item.Tag = "item_power"; }
                item.Left = x; item.Top = y;
                this.Controls.Add(item); items.Add(item); item.BringToFront();
            }
        }

        private void HandleItems()
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                PictureBox item = items[i];
                item.Top += itemSpeed;
                if (item.Top > this.ClientSize.Height) { items.RemoveAt(i); this.Controls.Remove(item); continue; }

                if (item.Bounds.IntersectsWith(pbPlayer.Bounds))
                {
                    if (item.Tag.ToString() == "item_heart")
                    {
                        if (playerHealth < maxHealth) { playerHealth++; ShowFloatingText("+1 HP", Color.HotPink, pbPlayer.Left, pbPlayer.Top - 30); }
                        else { score += 50; ShowFloatingText("+50 PTS", Color.Gold, pbPlayer.Left, pbPlayer.Top - 30); }
                    }
                    else if (item.Tag.ToString() == "item_power")
                    {
                        bulletLevel = maxBulletLevel;
                        ShowFloatingText("POWER UP (5s)!", Color.Cyan, pbPlayer.Left, pbPlayer.Top - 30);
                        timerPowerUp.Stop();
                        timerPowerUp.Start();
                    }
                    items.RemoveAt(i); this.Controls.Remove(item);
                }
            }
        }

        private void ShowFloatingText(string text, Color color, int x, int y)
        {
            Label lbl = new Label();
            lbl.Text = text; lbl.ForeColor = color;
            lbl.Font = new Font("Consolas", 12, FontStyle.Bold);
            lbl.AutoSize = true; lbl.Left = x; lbl.Top = y;
            lbl.BackColor = Color.Transparent;
            this.Controls.Add(lbl); effects.Add(lbl); lbl.BringToFront();
        }

        private void HandleEffects()
        {
            for (int i = effects.Count - 1; i >= 0; i--)
            {
                Label lbl = effects[i]; lbl.Top -= 3;
                if (lbl.Top < pbPlayer.Top - 150) { effects.RemoveAt(i); this.Controls.Remove(lbl); }
            }
        }

        private void Shoot()
        {
            if (sfxShoot != null)
            {
                try
                {
                    sfxShoot.Stop();
                    sfxShoot.Play();
                }
                catch { }
            }

            if (bulletLevel == 1)
                CreateBullet(pbPlayer.Left + pbPlayer.Width / 2 - 5, pbPlayer.Top - 20, 0);
            else if (bulletLevel == 2)
            {
                CreateBullet(pbPlayer.Left, pbPlayer.Top - 20, 0);
                CreateBullet(pbPlayer.Left + pbPlayer.Width - 10, pbPlayer.Top - 20, 0);
            }
            else
            {
                CreateBullet(pbPlayer.Left + pbPlayer.Width / 2 - 5, pbPlayer.Top - 20, 0);
                CreateBullet(pbPlayer.Left, pbPlayer.Top - 10, -4);
                CreateBullet(pbPlayer.Left + pbPlayer.Width - 10, pbPlayer.Top - 10, 4);
            }
        }

        private void CreateBullet(int x, int y, int speedX)
        {
            PictureBox bullet = new PictureBox();
            bullet.Size = new Size(70, 90);
            SetImage(bullet, "laze.png", Color.Yellow);
            bullet.Left = x; bullet.Top = y; bullet.Tag = speedX;
            this.Controls.Add(bullet); bullets.Add(bullet); bullet.BringToFront();
        }

        private void HandlePlayerBullets()
        {
            for (int i = bullets.Count - 1; i >= 0; i--)
            {
                PictureBox bullet = bullets[i];
                bullet.Top -= bulletSpeed;
                if (bullet.Tag is int speedX && speedX != 0) bullet.Left += speedX;

                if (bullet.Top < -100) { bullets.RemoveAt(i); this.Controls.Remove(bullet); continue; }

                for (int j = enemies.Count - 1; j >= 0; j--)
                {
                    if (bullet.Bounds.IntersectsWith(enemies[j].Bounds))
                    {
                        SpawnItem(enemies[j].Left, enemies[j].Top);
                        bullets.RemoveAt(i); this.Controls.Remove(bullet);

                        if (enemies[j].Tag.ToString() == "boss")
                        {
                            bossHealth--;
                            enemies[j].BackColor = (bossHealth % 2 == 0) ? Color.White : Color.Transparent;
                            if (bossHealth <= 0)
                            {
                                score += 1000;
                                ShowFloatingText("BOSS DEFEATED!", Color.Gold, enemies[j].Left, enemies[j].Top);
                                this.Controls.Remove(enemies[j]);
                                enemies.RemoveAt(j);
                            }
                        }
                        else
                        {
                            score += 50;
                            this.Controls.Remove(enemies[j]);
                            enemies.RemoveAt(j);
                        }
                        break;
                    }
                }
            }
        }

        private void EnemyAttackLogic()
        {
            if (enemies.Count > 0 && rnd.Next(0, 200) < enemyShootChance)
            {
                var shooter = enemies[rnd.Next(enemies.Count)];
                PictureBox bullet = new PictureBox();
                bullet.Size = new Size(80, 90);
                SetImage(bullet, "fire.png", Color.Red);
                bullet.Left = shooter.Left + shooter.Width / 2 - bullet.Width / 2;
                bullet.Top = shooter.Top + shooter.Height;
                bullet.Tag = "enemyBullet";
                this.Controls.Add(bullet);
                enemyBullets.Add(bullet);
                bullet.BringToFront();
            }
        }

        private void MoveEnemies()
        {
            foreach (var enemy in enemies)
            {
                enemy.Left += enemySpeed;
                if (enemy.Left > this.ClientSize.Width - enemy.Width - 10 || enemy.Left < 10)
                {
                    enemySpeed = -enemySpeed;
                    enemy.Top += 40;
                }
                if (enemy.Bounds.IntersectsWith(pbPlayer.Bounds) || enemy.Top > pbPlayer.Top)
                    GameOver("INVASION SUCCESSFUL!");
            }
        }

        private void HandleEnemyBullets()
        {
            for (int i = enemyBullets.Count - 1; i >= 0; i--)
            {
                PictureBox bullet = enemyBullets[i];
                bullet.Top += enemyBulletSpeed;
                if (bullet.Top > this.ClientSize.Height)
                {
                    enemyBullets.RemoveAt(i);
                    this.Controls.Remove(bullet);
                    continue;
                }
                if (bullet.Bounds.IntersectsWith(pbPlayer.Bounds))
                {
                    enemyBullets.RemoveAt(i);
                    this.Controls.Remove(bullet);
                    TakeDamage();
                }
            }
        }

        private void TakeDamage()
        {
            if (bulletLevel > 1)
            {
                bulletLevel--;
                ShowFloatingText("WEAPON DAMAGED", Color.Orange, pbPlayer.Left, pbPlayer.Top - 50);
            }
            playerHealth--;
            UpdateScoreBoard();
            pbPlayer.BackColor = Color.Red;
            System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
            t.Interval = 100;
            t.Tick += (s, ev) => { pbPlayer.BackColor = Color.Transparent; t.Stop(); t.Dispose(); };
            t.Start();
            if (playerHealth <= 0) GameOver("MISSION FAILED");
        }

        private void LoadHighScore()
        {
            try { if (File.Exists("highscore.txt")) int.TryParse(File.ReadAllText("highscore.txt"), out highScore); } catch { highScore = 0; }
        }
        private void SaveHighScore()
        {
            if (score > highScore) { highScore = score; File.WriteAllText("highscore.txt", highScore.ToString()); }
        }
        private void UpdateScoreBoard()
        {
            lblScore.Text = "SCORE: " + score + " | LEVEL: " + level;
            lblHealth.Text = "HP: " + playerHealth + " | GUN: " + bulletLevel;
            lblHighScore.Text = "BEST: " + highScore;
        }

        private void GameOver(string msg)
        {
            isGameOver = true;

            // [5] TẮT NHẠC KHI GAME OVER
            StopBackgroundMusic();

            gameTimer.Stop();
            timerPowerUp.Stop();
            timerTransition.Stop();
            SaveHighScore();

            Label lblOver = new Label();
            lblOver.Text = msg + "\n\nFINAL SCORE: " + score + "\n\n[PRESS ENTER TO RESTART]";
            lblOver.Font = new Font("Consolas", 18, FontStyle.Bold);
            lblOver.ForeColor = Color.White;
            lblOver.BackColor = Color.FromArgb(180, 0, 0, 0);
            lblOver.TextAlign = ContentAlignment.MiddleCenter;
            lblOver.Dock = DockStyle.Fill;
            this.Controls.Add(lblOver);
            lblOver.BringToFront();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Space && !isGameOver && !isTransitioning) Shoot();
            if (e.KeyCode == Keys.Enter && isGameOver) { Controls.Clear(); InitializeComponent(); SetupGame(); }
            if (e.KeyCode == Keys.Up) goUp = true;
            if (e.KeyCode == Keys.Down) goDown = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Up) goUp = false;
            if (e.KeyCode == Keys.Down) goDown = false;
        }
    }
}
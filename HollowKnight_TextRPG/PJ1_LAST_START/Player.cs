using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PJ1_LAST_START
{


    public interface ISKILL
    {
        string[] SKILL();
    }
    public interface IRECOVER
    {
        string[] RECOVER();
    }
    public interface IPADDING
    {
        string[] PADDING();
    }

    class Player : Creature, ISKILL, IRECOVER, IPADDING 
    {
        private int _Coin = 0;
        private int _Mp;
        private int _Battle_Choice;
        private static int _SKDamage;
        private int _Level = 0;
        private int _Exp = 0;
        private int _Levelup = 3;
        private int _Recover = 1;
        private bool _Get_Fury = false;
        private bool _Get_Bloo = false;
        Random rnd = new Random();

        public Dictionary<string, Item> Inventory = new Dictionary<string, Item>();

        public int Mp { get { return _Mp; } private set { _Mp = value; } }
        public int Coin { get { return _Coin; } set { _Coin = value; } }
        public int Battle_Choice { get { return _Battle_Choice; } private set { _Battle_Choice = value; } }
        public int Level { get { return _Level; } set { _Level = value; } }
        public int Exp { get { return _Exp; } set { _Exp = value; } }
        public int Levelup { get { return _Levelup; } set { _Levelup = value; } }
        public int SKDamage { get { return _SKDamage; } set { _SKDamage = value; } }
        public int Recover { get { return _Recover; } set { _Recover = value; } }
        public bool Get_Fury { get { return _Get_Fury; } set { _Get_Fury = value; } }
        public bool Get_Bloo { get { return _Get_Bloo; } set { _Get_Bloo = value; } }
        Menu menu = new Menu();

        public string[] PADDING()
        {
            return Animation[(int)State.PADDING];
        }
        public string[] SKILL()
        {
            Mp -= 1;
            return Animation[(int)State.Skill];
        }
        public string[] RECOVER()
        {
            return Animation[(int)State.Recover];
        }

        public void show_Inven()
        {
            int j = 1;
            if (Inventory.Count.Equals(1))
            {
                var Item = Inventory.Values.ElementAt(0);
                if (Item.Painting != null)
                {
                    if (j.Equals(1))
                    {
                        Console.Write("         Item : ");
                        Console.WriteLine($"{Item.Name}");
                        j--;
                    }
                    foreach (var painting in Item.Painting)
                    {
                        Console.WriteLine($"{painting}");
                    }
                }

            }
            else if (Inventory.Count.Equals(2))
            {
                var Item = Inventory.Values.ElementAt(0);
                var Item1 = Inventory.Values.ElementAt(1);
                if (Item1.Painting != null)
                {

                    if (j.Equals(1))
                    {
                        Console.Write("         Item : ");
                        Console.Write($"{Item.Name}, ");
                        Console.WriteLine($"{Item1.Name}");
                        j--;
                    }
                    Painting(Item.Painting, Item1.Painting);

                }
            }


        }
    
    
        public bool Player_Hurt(Creature Enemy, ref bool IsPadding, ref bool IsKill) {
            Random Pa_Suc = new Random();
            int Player_Avoid;
            Thread.Sleep(200);
            if (IsPadding == true)
            {
                if (Enemy.Name.Equals("영혼 전사"))
                {
                    Player_Avoid = rnd.Next(25);
                }
                else if (Enemy.Name.Equals("그릇된 기사"))
                {
                    Player_Avoid = rnd.Next(20);
                }
                else if (Enemy.Name.Equals("영혼 마스터"))
                {
                    Player_Avoid = rnd.Next(15);
                }
                else
                {
                    Player_Avoid = rnd.Next(10);
                }

                
                if (Player_Avoid > 5)
                {
                    Console.Clear();
                    menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                    Console.WriteLine("\n|-------------------------------------------------");
                    Painting(Animation[(int)State.PADDING], Enemy.Attack());
                    base.print($"{Enemy.Name}이 공격에 들어갑니다.");
                    base.print($"{Enemy.Name}의 공격에 패딩을 성공했습니다.");
                    Thread.Sleep(400);
                    Console.Clear();
                    Enemy.HP -= Attack_Power * 3;
                    menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                    Console.WriteLine("\n|-------------------------------------------------");
                    Painting(Animation[(int)State.ATTACK], Enemy.Attack());
                    base.print($"{Name}가 공격합니다.");
                    base.print($"{Name}가 {Attack_Power*3}의 피해를 입혔습니다.");
                    IsPadding = false;
 
                    if (Enemy.HP <= 0)
                    {
                        Thread.Sleep(400);
                        Console.Clear();
                        Painting(Animation[(int)State.IDLE], Enemy.Die());
                        print($"{Name}가 {Enemy.Name}을 처치했다.");
                        Exp += Enemy.Enemy_Exp;
                        print($"{Enemy.Enemy_Exp}의 경험치를 획득했다.");
                        IsKill = true;
                        return true;
                    }
                }
                else
                {
                    Console.Clear();
                    menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                    Console.WriteLine("\n|-------------------------------------------------");
                    Painting(Animation[(int)State.PADDING], Enemy.Attack());
                    base.print($"{Enemy.Name}가 공격에 들어갑니다.");
                    base.print($"{Enemy.Name}의 공격에 패딩을 실패했습니다.");
                    Thread.Sleep(400);
                    Console.Clear();
                    HP -= Enemy.Attack_Power;
                    menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                    Console.WriteLine("\n|-------------------------------------------------");
                    Painting(Animation[(int)State.IDLE], Enemy.Attack());
                    base.print($"{Name}가 {Enemy.Attack_Power}의 피해를 입었습니다.");
                    IsPadding = false;
                }

            }
            else
            {
                Console.Clear();
                HP -= Enemy.Attack_Power;
                menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                Console.WriteLine("\n|-------------------------------------------------");
                Painting(Animation[(int)State.IDLE], Enemy.Attack());
                base.print($"{Name}가 {Enemy.Attack_Power}의 피해를 입었습니다.");
                
            }

            if (HP > 0)
            {
                return false;
            }
            else
            {
                Console.Clear();
                Painting(Animation[(int)State.Die], Enemy.Attack());
                base.print($"{Name}이 {Enemy.Name}에게 졌습니다.");
                Thread.Sleep(400);
                return true;
            }
        }
        public void UseItem(string itemName)
        {
            if (Inventory.ContainsKey(itemName))
            {
                Inventory[itemName].Effect(this);
            }
            else
            {
                print($"{itemName}의 영혼이 느껴지지 않아");
            }
        }
        public bool Player_HpRecover()
        {
            if (HP.Equals(Max_HP))
            {
                return false;
            }
            else
            {
                HP += Recover;
                Mp--;
                if (Max_HP < HP)
                {
                    HP = Max_HP;
                }
                return true;
            }

        }
        public void Player_Levelup()
        {
            if(Exp > Levelup)
            {
                Console.WriteLine($"{Name}가 깨달음을 얻어 레벨업 했습니다.");
                while (Exp >= Levelup)
                {
                    Exp -= Levelup;
                    Levelup += 5;
                    Level++;
                    base.Attack_Power += 3;
                    Max_HP += 10;
                    SKDamage = base.Attack_Power * 2;
                    HP = Max_HP;
                    Mp = 10;
                    Recover += 5;
                }
            }
        }

    

    public bool Player_Attack(Creature Enemy, int Battle_Choice, ref bool Padding, ref bool IsKill)
        {
            int Enemy_Avoid;
            bool recover;
            if (Enemy.Name.Equals("영혼 전사")) {

                Enemy_Avoid = rnd.Next(40); 
            }else if(Enemy.Name.Equals("그릇된 기사"))
            {
                Enemy_Avoid = rnd.Next(35);
            }else if(Enemy.Name.Equals("영혼 마스터"))
            {
                Enemy_Avoid=rnd.Next(30);
            }
            else
            {
                Enemy_Avoid=rnd.Next(15);
            }

           if(Battle_Choice == 1)
            {
                Console.Clear();

                if (Enemy_Avoid > 3)
                {
                    Enemy.HP -= base.Attack_Power;
                    menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                    Console.WriteLine("\n|-------------------------------------------------");
                    Painting(Animation[(int)State.ATTACK], Enemy.Basic());
                    print($"{Name}가 {Enemy.Name}에게 {base.Attack_Power}의 타격을 가합니다");
                    Padding = false;
                }
                else
                {
                    menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                    Painting(Animation[(int)State.ATTACK], Enemy.Basic());
                    print($"{Enemy.Name}가 {Name}의 공격을 회피했습니다.");
                    Padding = false;
                }
                Thread.Sleep(200);
            }
            else if(Battle_Choice == 2)
            {
                Console.Clear();
                menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                Console.WriteLine("\n|-------------------------------------------------");
                Painting(Animation[(int)State.PADDING], Enemy.Basic());
                print($"{Name}가 {Enemy.Name}을 상대로 패딩을 시도합니다.");
                Padding = true;
            }
            else if(Battle_Choice == 3)
            {
                Console.Clear();
                if (Mp <= 0)
                {
                    print("Skill을 사용할 수 없습니다. 턴이 넘어갑니다.");
                    Padding = false;
                }
                else
                {
                    Mp--;
                    Enemy.HP -= SKDamage;
                    menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                    Console.WriteLine("\n|-------------------------------------------------");
                    Painting(Animation[(int)State.Skill], Enemy.Basic());
                    print($"{Name}가 {Enemy.Name}에게 {SKDamage}의 타격을 가합니다");
                    Padding = false;
                }
            }
            else
            {
                Console.Clear();
                recover = Player_HpRecover();
                menu.PrintText(new string[] {Name,
                                                    "HP : " + HP+"/"+Max_HP, "MP : "+Mp+"/10", "공격력 : " + Attack_Power, "스킬 공격력 : " + SKDamage,
                                                    "회복력 : " + Recover }, new string[] { Enemy.Name, "HP : " + Enemy.HP + "/" + Enemy.Max_HP, "공격력 : " + Enemy.Attack_Power }, 1, 1);
                Console.WriteLine("\n|-------------------------------------------------");
                Painting(Animation[(int)State.Recover], Enemy.Basic());
                if(recover.Equals(false))
                {
                    print("최대체력임으로 회복할 수 없습니다.");
                }
                else
                {
                    print($"체력을 {Recover}만큼 회복했습니다.");
                }
                Padding = false;
            }

           if(Enemy.HP <= 0)
            {
                Thread.Sleep(400);
                Console.Clear();
                Painting(Animation[(int)State.IDLE], Enemy.Die());
                print($"{Name}가 {Enemy.Name}을 처치했다.");
                Exp += Enemy.Enemy_Exp;
                print($"{Enemy.Enemy_Exp}의 경험치를 획득했다.");
                IsKill = true;
                return true;
            }
            else
            {
                Console.ReadLine();
                return false;
            }
        }

        public void Painting(string[] play, string[] ene)
        {
            int Space = 0;
            int maxLines = Math.Max(play.Length, ene.Length);
            for (int i = 0; i < maxLines; i++)
            {
                if (ene.Length > i && play.Length > i)
                {
                    Console.WriteLine(play[i] + "      " + ene[i]);
                }
                else if (ene.Length < i && play.Length > i)
                {
                    Console.WriteLine(play[i]);
                }
                else if (ene.Length > i && play.Length < i)
                {
                    Space = play[0].Length;
                    for (int j = 0; j < Space; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.WriteLine("      " + ene[i]);
                }

            }
        }
        public void Reset()
        {
            Name = "공허의 기사";   // 플레이어 이름 초기화
            Max_HP = 100;      // 최대 HP
            HP = Max_HP;       // 현재 HP
            Mp = 10;       // 현재 MP
            Level = 0;
            Attack_Power = 10; // 기본 공격력
            SKDamage = Attack_Power*2;     // 기본 스킬 공격력
            Level = 1;         // 시작 레벨
            Coin = 800;
            Levelup = 3;
            Inventory.Clear();
     
        }
        public Player()
        {
            Max_HP = 100;
            base.Name = "공허의 기사";
            base.Attack_Power = 10;
            base.HP = 100;
            SKDamage = base.Attack_Power * 2;
            Mp = 10;
            Coin = 300;
            /*IDLE*/
            base.Animation.Add(new string[] {
            "                                                                                       ",
            "                                                                                       ",
            "                     ++=    .=@                 @%=     .@@                            ",
            "                    ==:.   .=@@                  %@+     +@@                           ",
            "                    **:    :#@                    .@=     .%@                          ",
            "                    @%:    :%@                     %%:     +@@                         ",
            "                    @%.    :#-                      @+     .#*                         ",
            "                    @%:    :=                       @%.     %==                        ",
            "                    @@=    .+==                     @%.     #==                        ",
            "                    @@#.    #@@                     @*      %==                        ",
            "                     @%:    -@@%                   @@:     .% *                        ",
            "                     @@+     =@@@                **%=      -@@                         ",
            "                      @@:     :+%@@@@@@@@@@%%%%%%% *:      #@                          ",
            "                     %@@+       .-== +*****++= --== -     =@@                          ",
            "                   @@@+.                                :%@%%@                         ",
            "                  @@@-                                 :#@+..*@@                       ",
            "                 @@% -                               -% *:    =@@@                     ",
            "                @% *:                                -**-      -%@@                    ",
            "                *%=                                  ..          =@@                   ",
            "               ==#                                               .#@*                  ",
            "               ***=                                               =@%                  ",
            "               @@@=                                                :@@                 ",
            "               @@@*                                                .%@@                ",
            "               @@@*:-.            - +*#*=.                         .#@@                ",
            "               @@@ @@*          -%@@@@@@% -                        .#@@                ",
            "               @@@+@@@-        =@@@@@@@@@@:                       .%@@                 ",
            "               @@@@@@@*       .%@@@@@@@@@@#                       :@@@                 ",
            "                @@@@@@#       .@@@@@@@@@@@%.                      =@@@                 ",
            "                @@@@@@#       .%@@@@@@@@@@@.                      #@*                  ",
            "                 @@@@@*        -@@@@@@@@@@#.                     -@@=                  ",
            "                 @@@@% -         =%@@@@@@@%.                    -%@@                   ",
            "                  @@@=           .= *###*=.                   :+%@                     ",
            "                   @@@-                                     -*%@@    ***               ",
            "                    @@% +.                              .- +%@@@   @@%#%@@             ",
            "                       **+:-.....::-= +#%@@@@@@@@@%*=--+%@@                            ",
            "                           @@%%%%###%%%%%%%@@@@@@@@@@@@%#+==*%*=-==*%@@                ",
            "                              @%%#%%@@%%%#%%@%%###%@@@*=-----=-=+#@%                   ",
            "                              @#**#%@%#*****#%%%#**%@@%+=------#@@@                    ",
            "                             @% ***%@%%%#******#%@%#*#@@%+------=#@@                   ",
            "                            @@#**#@@#*#%%*******#%@%##@@@+---=*#%@@                    ",
            "                            @%#*#@@%***#@%#*******#%@%%%@%*+#@@@                       ",
            "                           -@% **%@@%#***#%@%#*******#@@%@@@@@                         ",
            "                           @%#*%@@%%%#****#@@%#******#%@@@@@                           ",
            "                           @% *%@@% **%@%#***#%@@%#******%@@@@                         ",
            "                          #@##@@@%***#%@#****#%@@@#*****#@@@@                          ",
            "                          @@#%@@@@%#***%@%#*****#%@@%#***#@@@                          ",
            "                          @%#@@@@@@@%***#%@%#*****#%@@%#**%@@                          ",
            "                          @%%@@%@@@@@%#***#%@@%#*****%@@@%#@@@                         ",
            "                           %%@%#@@@@@@@%#***#%@@%%#****#%@@@@@                         ",
            "                            @@% *%@@@@@@@@%#****#%@@@%#****#%@@                        ",
            "                            ****#@@@@@@@@@@@%#****#%@@@@%###@@                         ",
            "                             = -#*%@@@@@@@@@@@@@%#****##%@@@@@@                        ",
            "                               *++*@@@@@@@@%%%%@@@%##****###%@                         ",
            });
            Animation[(int)State.IDLE] = Flip(Animation[(int)State.IDLE]);
            /*ATTACK*/
            base.Animation.Add(new string[] {
        "                                                                                    ",
        "                                                                                    ",
        "                                                                                    ",
        "  @#    .-=        **#.     =@@                                                     ",
        "  @%:   .           @@+     .#@                                                     ",
        "  ===    .=-         @%:     *@@                                                    ",
        "    *.   -@@         @@+     -@@                                                    ",
        "   =%-   .#@@         **:    .@@@                                                   ",
        "    @%.   -@@         ===     %@@                                                   ",
        "     @*    *@%         *#.    %@@                                                   ",
        "     @@+   .#@@        @#.   .%@@                                                   ",
        "      @@*.  .*@@       @#.   .@@@                                                   ",
        "       @@#:  .*@@@    @@*    :%@@+*#%@@@@                                           ",
        "        %@%+-=+%@@@@@%%#:    .+#=    .-+%@@                                         ",
        "         @@@@@@%*+=:.:=.                 -%@@                                       ",
        "       %%@%*=-.                             =++                                     ",
        "    @@@*-.                                   -==                                  @ ",
        "   ***.                                       +**                             =+=   ",
        "  == .                                        :@@*                         -:#*=    ",
        " **=                                           +@%                       +=--:      ",
        " @@=                                           .%@@                   -:.++#        ",
        ":@%:                                            +@@                 %-  .           ",
        "*@%.                                            .%@@             @%*+ .+*           ",
        "%@%.    ::.                                      *@@           #*+==++@             ",
        "@@%.   +@@%+.                                    +@@       ==%#+==++=               ",
        " @@-   *@@@@%:                                   +@@     **+-+==+-==                ",
        " @@*.  -@@@@@%:                                  *@@  ==-#+====*%=                  ",
        " @@@:   %@@@@@%.                                :@@@@*+=:====:=*                    ",
        "  @@*.  :@@@@@@*                               .*@@@#+=====+#-                      ",
        "   @@-   =@@@@@@:                             .*@@@@##***+#@.                       ",
        "    @%.   =@@@@@+                           .+%@@@@@@@@@@@@@     @                  ",
        "     @#.   -#@@%-                        .=#@@@@@@@@@@@@@@@@%%%%######%%@@          ",
        "      @#:    .:.                     .:=#%@@@@@@@%%%%%%###****************#%@@      ",
        "       @%=                      .:=+*%@@@@@@@@@@%#*#*******###%%%%%@@@@@%%%%@@@@    ",
        "         @#-.             .-=+#%@@@@@@@@@@@@@@@@@+***##%%@@@@%%#####********##%@@   ",
        "           %##*+=====+##%@@@@@@@%#%@@@@@@@@@@@@@@**#**=- ##********###%%%%%%%%@@@** ",
        "              @@@@       @@%#%%#**#@@@@@@@@@@@@@@@ %  -******##%%@@@@@@@@@          ",
        "                         @@%#@%***%@@@@@@@@@@@@@@@  *****#%%@@@@@%%##%@@            ",
        "                         =@@%@#**#@@@@@@@@@@@@@@@@@  %%@@@@@%%##***#%@@             ",
        "                          %%#@#**#@@@@@@@@@@@@@@@@@@@@@@%##*****##%@@               ",
        "                           **@#**#@@@@@@@@@@@@@@@@@@@@  *****##%@@@                 ",
        "                            %*+==%@@@@@@@@@@@@@@@@@@@@%==#%%@@@@                    ",
        "                             ==-.%@@@@@@@@@@@@@@@@@@@@@@@@@                         ",
        "                               ++%@@@@@@@@@@@@@@@@@@@@@@@@                          ",
        "                                 @@@@@@@@@@@@@@@@@@@@@@@@@@@                        ",
        "                                 %@@@@@@@@@@@@@@@@@@@@@@@@@@@                       ",
        "                               @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                      ",
        "                              @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                     ",
        "                               @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@                    ",
        "                                @@@@@@@@@%             @@@@@@@@@@                   ",
        "                                   @@@@@@**               @@@@@@@@                  ",
        "                                                             @@@@@@                 "
            });
            Animation[(int)State.ATTACK] = Flip(Animation[(int)State.ATTACK]);
            /*Die*/
            base.Animation.Add(new string[] {
              "                                                                                          ",
              "                                                                                          ",
              "                                                                                          ",
              "                                                                                          ",
              "                                                                                          ",
              "                                                                       ...                ",
              "                                                                    .:===::.              ",
              "                                                            ..:--=+#%@@%%%%#=             ",
              "                                                         .-*%@@@@@@%###%@@#*-             ",
              "                                                       .+%@@@%%%@%#**#@@#:.               ",
              "                                                      -#@@%#**%@%***%@@@%%+-.             ",
              "                                                     -%@%#***%@@#**#@@%%%@@@#-            ",
              "                                                    :%@%***#%@@%***%@%#*%@@@@#:           ",
              "                                                   .*@@#**#@@@@%**#@@%%@@#=::.            ",
              "                                                   +@@%**#%%%%@#**#@@@%*=:..              ",
              "                                                  =%@%#**%@##%@#**#@@@@%%%%%*==*#%        ",
              "                                ..::------::..   -%@@#**%@%*%@@#**%@@%%%%@@@@@@@@@        ",
              "                         .:-=+*#%%@@@@@@@@@@%#*=+%@%#**%@@##%@%***%@@@@@@@@@@@@@@@        ",
              "                   ..-+*#%@@@%#*+=--:::::-=*#@@@@@%#*#@@@#*#@@#***%@@@@@@@@@@@@@@@        ",
              "  ########*+:.  .=*#%@%#*+-:..               .-*%@@%%@@@#*#%@%***#%@@@@@@@@@@@@@@@        ",
              "  +===++*#%%@%##%@@@*-.                         .=%@@@@#**%@%#***#@@@@@@@@@@@@@@@@        ",
              "          ..-+%@@@@#:                             .+@@@%*%@@%****%@@@@@@@@@@@@@@@*        ",
              "              .-+%@@%+.                             :%@@@%@%#***#@@@@@@@@@@@@@@@%:        ",
              "                 .-==:.                              .#@@%%*****%@@@@@@@@@@@@@@@@=        ",
              "  ######*+=:.                       .:-=+**++-:       .*@@%#***#@@@@@@@@@@@@@@@@@@        ",
              "  ===+*#@@@@%+:                   :+#@@@@@@@@@@#-      .*@@%**#@@@@@@@@@@@@@@@@@@@        ",
              "       :#@#*%%*.                 -%@@@@@@@@@@@@@%=      -%@@#%@@@@@@@@@@@@@@@@@@@@        ",
              "       .#@#....                 :%@@@@@@@@@@@@@@@#.      #@@%%%%@@@@@@@@@@@@@@@@@@        ",
              "       .#@%:                    =@@@@@@@@@@@@@@@@#       -@@@%**##%@@@@@@@@@@@@@@@        ",
              "       .*@%=                    :#@@@@@@@@@@@@@@*.       .*@@@#*****##%%@@@@@@@@@@        ",
              "        =%@*.                    .=#@@@@@@@@%#=.          =@@@@@@%%%%%%@@@@%++***=        ",
              "        :#@%:                       :-===--:.             :#@@%%%%%%%%@@@%+.              ",
              "         +@@-                                              *@@%####%%@@%=.                ",
              "         -%@*.                                             +@@@@@@@%*+:.                  ",
              "         .+@@=                                            .+@@%=-::.                      ",
              "          :#@#:                                    .      :#@@+                           ",
              "           =%@+.                            .:=+*#%%#*-   -%@@+                           ",
              "           .*@%-                         .-*%@@@@@@@@@%- .*@@#:                           ",
              "            -%@#.                      .*%@@@@@@@@@@@@#.:#@@%-                            ",
              "             =%%=                      -@@@@@@@@@@@%#=:+%@@#:                             ",
              "             .#@%+.                    .+%@@@@@%#+-:-*%@@%+.                              ",
              "            .+%@#=.                      .::::...-+#@@%+:.                                ",
              "         .:+%@%=. .--.                    ..:-*#%@%*=:                                    ",
              "  #*+==+*%@%#=.    +%%*=:.        ..:-==+##@@%#*=:.                                       ",
                                                                                               
            });
            Animation[(int)State.Die] = Flip(Animation[(int)State.Die]);
            /*JUMP*/
            base.Animation.Add(new string[] {

    "                                                                                   ",
    "                                                                                   ",
    "                                                                                   ",
    " @@@+.-@@@                   @%*-.    :+%@@                                        ",
    " @@%: :#@@@@=                  *@*:    .=%@@                                       ",
    "@@@*. .=#@@@                    @@*:    :+%@@                                      ",
    "@@@+.  .-#@@                     @@%-    :*@@@                                     ",
    "@@@+.   +@@@                      @@#:   .=%@@                                     ",
    " @@*.   +@@@                       @@+.   :#%%%                                    ",
    " @@%=   -%@@                       @@%-   .****                                    ",
    "  %%*.   +@@                       @@@+    =#%%####                                ",
    "   *%=   .+@*                 @@@@@@@@+   .+@@@%%%@@@@                             ",
    "   :@%=   .=*#            #%@@@%*==%@%-   .*@%=:.:+%@@@@                           ",
    "    @@%=    -#%       @@@@%#+=-.  -%%+.   :%@+.    .=#@@@@                         ",
    "     @@@+.   .=%@ @@@@%#+=:.     .-+-    .*@#:       .-#@@@                        ",
    "       @@#-    :+###+-.                 .=##-          .=%@@                       ",
    "        @@%+.    ..                      ...           ..=%@*                      ",
    "        @@@@#:                                            =%@@                     ",
    "         @%%+.                                             -%@@                    ",
    "         @@%:                                               =%@@                   ",
    "        :@@*.                                                =%@+                  ",
    "         @@+.                                                .+@@                  ",
    "        :@@*.                ....                             :#@@                 ",
    "         @@#:              :*%%%%#+:                           =%@@                ",
    "         @@%=             :#@@@@@@@@*:                         :#@@@               ",
    "          @@#-            :%@@@@@@@@@%=                        :#@@#               ",
    "           @@#.           .*@@@@@@@@@@%-                       .#@@@@%%@@.         ",
    "            @@*:++:        :%@@@@@@@@@@#:                      =@@@#+==%@@         ",
    "            @@@%@@@+.       =@@@@@@@@@@%-                     =@@@*==+%@@          ",
    "             @@@@@@@#.      .=%@@@@@@@@%-                   .+@@@*==#@@@           ",
    "              @@@@@@@%-       :#@@@@@@%=                  .=#@@@+==%***            ",
    "               @@@@@@@%.        :+*##+:                .-+%@@@%+===#-==            ",
    "                @@@@@@@*.                           .-*%@@@@@#=====++**            ",
    "                  @@@@@%.                      .::=*#@@@@@@@@%#+=+#@@@             ",
    "                   @@@@=                   .:-+#%@@@@@@%##%%@@@@%@@@=              ",
    "                     @@#-.            .:-+#%@@@@@%##*%@%#***#%%@@@@                ",
    "                       @@#+---==++**##%@@@@%%@@%%@#***#@@%#****#%@@:=-             ",
    "                          @@@@@@@@@@@@@%%%#*#@@%#%@#****#%@%#*****#%@@@%           ",
    "                                    @@@%@#*%@@@%*#%@%******#%%%#****#%%%@          ",
    "                                    @@@@%#%@@@@%***#%%#******#%@%#****#*@@         ",
    "                                    @@@%#%@@@@@@%****#%%#******#%@%##**#@@@        ",
    "                                    @@@%%@@@@@@@@%*****%%%#******#%@@%**%@@        ",
    "                                    @@@%%@@@@@@@@@%#*****#%%##*****#%@%##@@@       ",
    "                                     @@@@@@@@@@@@@@@%#*****#%@%#*****#@@#%@@       ",
    "                                     @@@@@@@@@@@@@@@@@@%#****#%@%%****#@@%@@       ",
    "                                      @@@@@@@@@@@@@@@@@@@%#*****%@%#***%@@@        ",
    "                                       %@@@@@@@@@@@@@@@@@@@@#****#@@#**#@@@        ",
    "                                       *@@@@@@@@@@@@@@@@@@@@@@#***#%@#**%@@        ",
    "                                        @@@@@@@@@@@@@@@@@@@@@@@%#**#@@#*%@         ",
    "                                         @@@@@@@@@     @@@@@@@@@@%**%@%#@@         ",
    "                                          **@@@@@@       @@@@@@@@@%##@@%@          ",
    "                                            @@@@@@        @@@@@@@@@@%@@@@          ", 
           });
            /*Skill*/
            Animation[(int)State.PADDING] = Flip(Animation[(int)State.PADDING]);
            base.Animation.Add(new string[] {
"                                                                                              ",
"                                                                                              ",
"                                                                                              ",
"                                .+@@@@@@@@@@@%*:.                          .#@@@@@@@@@@@+.    ",
"                                =@@@@@@@@@@%+.                              :%@@@@@@@@@@*.    ",
"                               :%@@@@@@@@@*:                                 +@@@@@@@@@@#.    ",
"                               *@@@@@@@@@+.                                  -@@@@@@@@@@#.    ",
"                              .#@@@@@@@@#. .::-=++*******+++=-:..            =@@@@@@@@@@*.    ",
"                              :%@@@@@@@@%*#%@@@@@@@@@@@@@@@@@@@@%#+-.       :#@@@@@@@@@@=     ",
"                              :%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*:.  .-%@@@@@@@@@@#.     ",
"                              :%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#==#@@@@@@@@@@@@=      ",
"                              .#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*.      ",
"                              .#@@@@@@@@@@@@@@@@@@@@@@%%%%%%%%%@@@@@@@@@@@@@@@@@@@@@@#.       ",
"                             .*@%%######%%%%@@@@@@%%%%####***###%%%@@@@@@@@@@@@@@@@@#:        ",
"                             +%%#**++==+**#%%%%@%%%###**+-::::-+*##%%@@@@@@@@@@@@@@+.         ",
"                            :%%#*+-..  ..-*##%%%%%##**+:.      .-*##%%@@@@@@@@@@@#-           ",
"                            =%#*=.       .=*########*=.         .=*##%%@@@@@@@@%+.            ",
"                           .###+.         -*#######*+:           -*##%%@@@@@@@+.              ",
"                           :%#*-          :*#######*+.           -*##%%@@@@@@@=               ",
"                           =%#*-         .=*##%%%###+:          .+##%%%@@@@@@@+               ",
"                           +%##+.       .-*##%%%%%##*=.        .+##%%%@@@@@@@@+               ",
"                          .*@%%#*-.....-+##%%%@@@%%%##+-.....:=*##%%%@@@@@@@@@=               ",
"                          .*@@@%%%##*##%%%%@@@@@@@@@%%%##***###%%%%@@@@@@@@@@%:               ",
"                           +@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%%%@@@@@@@@@@@@@@@#.               ",
"                           -%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@=                ",
"                           .+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*.                ",
"                            .*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%:                 ",
"                             .+@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%-                  ",
"                               -#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#:                   ",
"                                .+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%+.                    ",
"                                  :+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*-.        .             ",
"                                    -@@@@@@@@@@@@@@@@@@@@@@@@@@%%#+-.      .:=+#%#-           ",
"                                   .*@@@@@@@@@@@@@@@@@@@@@@@@@**#%+.   .:=*#####%%%:          ",
"                                  .=@@@@@@@@@@@@@@@@@@@@@@@@@@%##%%#=+#########%%%+.          ",
"                                 .*@@@@@@@@@@@@@@@@@@@@@@@@@@@%##%%%%#####%%%#+-:.            ",
"                               .=%@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%##%%%%%%#*=-.                 ",
"                            .:+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%###%%%@+.                     ",
"                         .-+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%%###%%%#.                     ",
"                     .-+#%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%##%%%%#:                     ",
"                 .-+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%#*=:.                       ",
"             .-+#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%+.                          ",
"          :=*%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#:                         ",
"       :=#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@*-.                      ",
"    :=#@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%+-.                   ",
" .-#@@@@@@@@%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%#+=:..             ",
"-#@@@@@@%*-:*@@@@@@@@@@@@%*+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%#+=-:.       ",
"@@@@@%*-. .+@@@@@@@@@@#=:. =@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%#*=:.  ",
"@@@%+:    :@@@@@@@@%+:.   -%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%*-",
"@@+:      *@@@@@@@%:    .+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
"%-       .#@@@@@@%:   .=%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
":        :%@@@@@@= .-*%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
"         -@@@@@@%=+%@@@@@@@@%#=*@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@",
            });
            Animation[(int)State.Skill] = Flip(Animation[(int)State.Skill]);
            /* Recover */
            base.Animation.Add(new string[]{
"                                                                                            ",
"                                                                                            ",
"                                                                                            ",
"                                                                                            ",
"                                                                                            ",
"               .   :# =@%                  :=  ...         -:  ..    =%.  .                 ",
"                .   *- #@=         :-====-#*-       *=   -%%.  .    *@#:  ..                ",
"                ..  .#.:@%.     :*%@@@@@@@@@#=.     %%  =@#.      .#@@@+  ..         .......",
"                 .   :+ *@=    +@@@@@@@@@@@@**%+.   #@.-@%.       *@%==   ...........       ",
"                  .   -:.%%   *@@@@@@@@@@@@@= .*%:  #@-%%:   :#. +@@:    ...           .=*- ",
"                  .   :- +@= =%@@@@@@@@@@@@@%:  +@- *@#@=    == -@@=   ....   =#.    .*@@#: ",
"                ...   -. .%# #-+@@@@@@@@@@@@@%=  %@-*@@#   *.   %@*          :@@.   -%@#-   ",
"    ... .......           =@=@:=@@@@@@@@@@@@@@@%*@@%#@@: .-+*#%%@@*=:   -.   #@#   +@%=    .",
"   .              .:-==--:.%%@:=@@@@*-:. .=@@@@@@@@@@@%=##=-=%@@@@@@@#=%*.  =@%: .#@*.    . ",
"   .   *+ .   .=*%@@@@%#%@@%@@-+@@%:      -@:*@@@@@@@@@@=    +@@@@@@@@@*   .%@- :%%-    ..  ",
"   ..   ..%%-*@@@@@@@#   .=%@@%@@@:       =@. *@@@@@@@@#    =%@@@@@@@@%-+  #@= -%#.   ..    ",
"    ..    .#@@@@@@@@@#     :@@@@@*  :-    *%...%@@@@@@@@**#%@@@@%%@@@@@:+:+@= :%+    .....  ",
"      .   -@@@@@@@@@@@#=:..+@@@@@%: =@+*#%@@@@@@@@@@@@@@@@@%*-:    .=%@*-%@= :%-    ...   ..",
"     ..  .#-@@@@@@@@@@@@@@@@@@@@@@%*%@@@@@@@@@@@@@@@@@@@@%=.         .%@%@*-:#-             ",
"     .   +-=@@@#+=---=+#%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@#.        :+##*%@@@@@@%#    --.**   ",
"     .   #.%@#:          :+%@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%:     -#@#:  -*@@@@@@@*..#%=     .",
"... ..  .%*@#              .+@@+: .%@@@@@@@@@@@@@@@@@@#..-#+  .#@@#     #@@@@@@@@#..     ...",
"   .    .@@@=              .#%:    *@@@@@@@@@@@@@@@@@@+    =*:%@@@#...-#@@@@@@@@@-+    ..   ",
".     -- #@@=              #%.     %@@@@@@@@@@@@@@@@@@%     =@@@@@@@@@@@@@%%%@@@@-+.  ..    ",
"%-    :%-=@@#             +@-     =@@@@@@@%%##%@@@@@@@@*     +@@@@@@@@*=:    :+%@*:+   .....",
"@@=    .:.%@@= .:---::.  .@#     -@@@@%+-.      .-*@@@@@*.   .@@@@@@+.         :%%+*        ",
"-%@+      -@@@%@@%**#@@%**@#    =@@@%=             .=%@@@%+:.=@@@@#.            +@@%%+.=.   ",
" :#@*.   :*@@@@@#    .=@@@@@+=+%@@@+                 .*@@@@@@@@@@+              =@@#- -+=*#%",
"   +@%= =@@@@@@@%.     *@@@@@@@@@@=                    +@@@@@@@@*               *@@+=*%@#*=:",
"    .*@%@@@@@@@@@%*===+@@@@@@@@@@+-+                    *@@@@@@@+              .%@@%*=:     ",
"..    -@@@@@@@@@@@@@@@@@@@@@@@@@#=#.                    .%@@@@@@*  :+        :+%@@-       ..",
"  .   ==#@@@@@%#****#%@@@@@@@@@@=:%.                     +@@@@@@+  ..      =#%@@@=    ....  ",
"  .   *:*@@%%%+.      .-*@@@@@@@. .                      -@@@@@@+      ..=#+=%@@=    ....   ",
"  .   *:*@%: :+%*-.      #@@@@@@.                        :@@@@@@- :+##+==#%#@@%-        ..  ",
"  ..  ++#@=     :+#*=.   =@@@@@@.      ..      ..        -@@@@@@-#@@#    :@@@@*..-: :=.  .  ",
"  ..  :@@@=       .==+*+-:@@@@#@.    .#%:      :@#.      =@@@@@@@@@@%===*%@@@@@@%*- +=   .  ",
"   .   *@@#       .**  .:=#@@@++:    #%. :-==-: .%#      *%@@@@@@@@@@@@@@@@@@@@@#       ..  ",
"   ..  .%@@+              :@@@%      %%+%@@@@@%%+%%  .#-.#.%@@@@@@@@%*-:..:=#@@=*.  .....   ",
"    .   :%@@*.             +@@@=     -@#:.=@@- .*@-  :: +--@@@@@@@%=         *@-*:  .       ",
"     .   .#@@%=.            #@@%.     =*.:*@@#-:*=      + *@@@@#@+           :@#%:  .       ",
"      .    =%@@%+:     =*%%%%@@#-     =@@@@@@@@@@+        +@@*.+:   .:       -@@#   .       ",
"       .    .+%@@@%*=:#@@@=:=%@-    : .#@@@@@@@@@-  -:    =@+...    -:       #@%:  ..       ",
"        ..     -*%@@@@@@@@#=:*@@-:-:%++#@@@@@@@@#-:-#=   .%@*.              +@%:   .        ",
"          ..      .:-#=@@%##%@@%-.+###@@@@@@@@@@@@@@%#=  ::     ....      .#@*.   .         ",
"            ....     =-%+    .-##- .:*%*%@@@@@@@%@%+=.:       ...      .-*@*:    .          ",
"                ...   +@+          --:. :@@@@@@@.=#      .......     *%%#=.    ..           ",
"                  ..   :**-.             +%@#%@= .:   ...     ..  ----.      ..             ",
"                   ..    .-+=-.  ......   +% -%.     .         .          ...               "
         });
        }
    }
}
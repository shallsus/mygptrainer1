using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

namespace PJ1_LAST_START
{
    class System
    {
        public string currentEnemy = "";
        public bool battle = false;
        public bool shop = false;
        public bool total_GameEnd = false;
        public bool really_End = false;

        public bool menu = true;
        public bool Loading = false;



        public int menu_choice = 0;
        public int map_choice = 0;
        public int battle_choice = 0;
        public int shop_choice = 0;
        public int buy_choice = 0;
        public int Inventory_Choice=0;

        public bool Padding = false;
        public bool isKill = false;
        public bool isAttack = false;
        public bool isDead = false;
        public bool isFuryExist = true;
        public bool isHeartExist = true;
        public int level = 0;
        public bool print_conv = false;
        public bool inven = false;
        public bool again = false;
        public void message(string play, string ene)
        {
            string message = $"{play}가 {ene}를 만났습니다. 전투에 들어갑니다.";
            print(message);
        }
        public void message1(string play)
        {
            string message = $"{play}의 행동을 정해주세요. 1.공격 2.패딩 3.스킬 4.회복";
            print(message);
        }
        public void message_Attack(string play, string ene, int power)
        {
            string message = $"{play}가 {ene}를 공격합니다. {power}만큼의 피해를 입혔습니다.";
            print(message);
        }
        public void message_Padding(string play, string ene, int power)
        {
            string message = $"{play}가 {ene}를 공격합니다. {power}만큼의 피해를 입혔습니다.";
            print(message);
        }
        public void print(string mes)
        {
            foreach (var ch in mes)
            {
                Console.Write(ch);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

    }
    class Program
    {
        // Win32 API 함수 선언
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        // ShowWindow 함수의 매개변수
        const int SW_MAXIMIZE = 3;

        static void Main(string[] args)
        {
            // 현재 콘솔 창 핸들 가져오기
            IntPtr handle = GetConsoleWindow();

            // 콘솔 창을 최대화
            ShowWindow(handle, SW_MAXIMIZE);


            Console.SetWindowSize(240, 70);
            /*Menu Scene */
            Menu menu = new Menu();
            System sys = new System();
            Player play = new Player();
            Enemy1 en1 = new Enemy1();
            Enemy2 en2 = new Enemy2();
            Enemy3 en3 = new Enemy3();
            Enemy4 en4 = new Enemy4();
            Shop sh = new Shop();

            sys.again = false;

            while (!(sys.really_End))
            {
                sys.menu = false;
                while (!(sys.total_GameEnd))
                {


                    while (!sys.menu)
                    {
                        ArrPaint(menu.menu);

                        SpacePaint(menu.menu);
                        Console.Write("           ");
                        Console.WriteLine("1. 처음하기");
                        /* 시간이 있다면 *///Console.WriteLine("2. 이어하기");

                        SpacePaint(menu.menu);
                        Console.Write("           ");
                        Console.WriteLine("3. 종료하기");

                        SpacePaint(menu.menu);
                        Console.Write("           ");

                        while (true)
                        {

                            if (!int.TryParse(Console.ReadLine(), out sys.menu_choice))
                            {
                                Console.Clear();
                                ArrPaint(menu.menu);
                                SpacePaint(menu.menu);
                                Console.Write("           ");
                                Console.WriteLine("1. 처음하기");
                                /* 시간이 있다면 *///Console.WriteLine("2. 이어하기");
                                SpacePaint(menu.menu);
                                Console.Write("           ");
                                Console.WriteLine("3. 종료하기");
                                SpacePaint(menu.menu);
                                Console.Write("       <");
                                Console.WriteLine("숫자로 입력하세요>");
                                SpacePaint(menu.menu);
                                Console.Write("           ");
                                continue;
                            }
                            if (sys.menu_choice.Equals(1) || sys.menu_choice.Equals(3))
                            {
                                if (sys.menu_choice.Equals(1))
                                {
                                    sys.currentEnemy = "";
                                    sys.battle = false;
                                    sys.shop = false;
                                    sys.total_GameEnd = false;
                                    sys.Loading = false;
                                    sys.menu_choice = 0;
                                    sys.map_choice = 0;
                                    sys.level = 1;
                                    sys.Padding = false;
                                    sys.really_End = false;
                                    sys.shop_choice = 0;
                                    sys.isFuryExist = true;
                                    sys.isHeartExist = true;
                                    if (sys.again.Equals(true))
                                    {
                                        play.Reset();
                                    }
                                    en1.reset();
                                    en2.reset();
                                    en3.reset();
                                    en4.reset();
                                    sys.isFuryExist = true;
                                    sys.isHeartExist = true;
                                    

    }
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                ArrPaint(menu.menu);
                                SpacePaint(menu.menu);
                                Console.Write("           ");
                                Console.WriteLine("1. 처음하기");
                                /* 시간이 있다면 *///Console.WriteLine("2. 이어하기");
                                SpacePaint(menu.menu);
                                Console.Write("           ");
                                Console.WriteLine("3. 종료하기");
                                SpacePaint(menu.menu);
                                Console.Write("       ");
                                Console.WriteLine("<다시 입력하세요>");
                                SpacePaint(menu.menu);
                                Console.Write("           ");
                            }
                        }
                        if (sys.menu_choice.Equals(3))
                        {
                            sys.really_End = true;
                            sys.menu = true;
                            sys.total_GameEnd = true;
                            sys.Loading = false;
                        }
                        else
                        {
                            sys.menu = true;
                            sys.total_GameEnd = false;
                            sys.Loading = true;
                        }

                    }
                    while (sys.Loading)
                    {
                        Console.Clear();
                        ArrPaint(menu.Map_Choice_Background);
                        SpacePaint(menu.Map_Choice_Background);
                        Console.WriteLine("Text Hollow Knight에 오신 것을 환영합니다.이동하실 곳을 선택해주세요");
                        SpacePaint(menu.Map_Choice_Background);
                        Console.Write("        ");
                        Console.WriteLine("1. 던전 2. 성유물의 재단 3. 시작 화면 이동 4. 인벤토리");
                        SpacePaint(menu.Map_Choice_Background);

                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out sys.map_choice))
                            {
                                Console.Clear();
                                ArrPaint(menu.Map_Choice_Background);
                                SpacePaint(menu.Map_Choice_Background);
                                Console.WriteLine("Text Hollow Knight에 오신 것을 환영합니다.이동하실 곳을 선택해주세요");
                                SpacePaint(menu.Map_Choice_Background);
                                Console.WriteLine("1. 던전 2. 성유물의 재단 3. 시작 화면 이동 4. 인벤토리");
                                SpacePaint(menu.Map_Choice_Background);
                                Console.WriteLine("숫자로 입력하세요>");
                                SpacePaint(menu.Map_Choice_Background);
                                continue;
                            }

                            // 입력한 값이 1, 2, 3 중 하나인지를 확인
                            if (sys.map_choice.Equals(1)|| sys.map_choice.Equals(2) || sys.map_choice.Equals(3) || sys.map_choice.Equals(4))
                            {
                                if (sys.map_choice.Equals(1))
                                {
                                    sys.print_conv = true;
                                    sys.currentEnemy = en1.Name;
                                    sys.shop = false;
                                    sys.battle = true;
                                    Console.Clear();
                                    sys.Loading = false;
                                }
                                else if (sys.map_choice.Equals(2))
                                {
                                    sys.shop = true;
                                    sys.battle = false;
                                    Console.Clear();
                                    sys.Loading = false;
                                }
                                else if(sys.map_choice.Equals(3))
                                {
                                    sys.shop = false;
                                    sys.battle = false;
                                    sys.menu = false;
                                    Console.Clear();
                                    sys.Loading = false;
                                }
                                else
                                {
                                    sys.shop = false;
                                    sys.battle = false;
                                    sys.Loading = false;
                                    Console.Clear();
                                    sys.inven = true;
                                }
                                break;
                            }
                            else
                            {
                                // 잘못된 숫자 입력 처리
                                Console.Clear();
                                ArrPaint(menu.Map_Choice_Background);
                                SpacePaint(menu.Map_Choice_Background);
                                Console.WriteLine("Text Hollow Knight에 오신 것을 환영합니다.이동하실 곳을 선택해주세요");
                                SpacePaint(menu.Map_Choice_Background);
                                Console.WriteLine("1. 던전 2. 성유물의 재단 3. 시작 화면 이동 4. 인벤토리");
                                SpacePaint(menu.Map_Choice_Background);
                                Console.WriteLine("<잘못된 입력입니다. 다시 입력하세요>");
                                SpacePaint(menu.Map_Choice_Background);
                            }
                        }

                    }



                    while (sys.battle)
                    {
                        if (sys.print_conv.Equals(true))
                        {
                            if (sys.level != 5)
                            {
                                /*던전 들어감*/
                                Console.WriteLine("\n                                                              Level  :  " + sys.level);
                                if (sys.level.Equals(1))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en1.Name, "HP : " + en1.HP + "/" + en1.Max_HP, "공격력 : " + en1.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                }else if (sys.level.Equals(2))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en2.Name, "HP : " + en2.HP + "/" + en2.Max_HP, "공격력 : " + en2.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                }else if (sys.level.Equals(3))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en3.Name, "HP : " + en3.HP + "/" + en3.Max_HP, "공격력 : " + en3.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                }else if (sys.level.Equals(4))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en4.Name, "HP : " + en4.HP + "/" + en4.Max_HP, "공격력 : " + en4.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                }

                            }
                            if (sys.level.Equals(1))
                            {

                                Painting(play.Basic(), en1.Basic());
                                sys.currentEnemy = en1.Name;
                                sys.message(play.Name, sys.currentEnemy);
                            }else if (sys.level.Equals(2))
                            {
                                Painting(play.Basic(), en2.Basic());
                                sys.currentEnemy = en2.Name;
                                sys.message(play.Name, sys.currentEnemy);
                            }else if (sys.level.Equals(3))
                            {
                                Painting(play.Basic(), en3.Basic());
                                sys.currentEnemy = en3.Name;
                                sys.message(play.Name, sys.currentEnemy);
                            }else if (sys.level.Equals(4))
                            {
                                Painting(play.Basic(), en4.Basic());
                                sys.currentEnemy = en4.Name;
                                sys.message(play.Name, sys.currentEnemy);
                            }
                            else
                            {
                                /*  Ending Credit */
                                Painting0(menu.ending);
                                sys.battle = false;
                                sys.total_GameEnd = true;
                                sys.really_End = true;
                                break;
                            }
                            sys.print_conv = false;
                        }
                        while (true)
                        {
                            sys.message1(play.Name);
                            if (!int.TryParse(Console.ReadLine(), out sys.battle_choice))
                            {
                                Console.Clear();
                                if (sys.level != 5)
                                {
                                    Console.WriteLine("\n                                                              Level  :  " + sys.level);
                                }
                                if (sys.level.Equals(1))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en1.Name, "HP : " + en1.HP + "/" + en1.Max_HP, "공격력 : " + en1.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en1.Basic());
                                }
                                else if (sys.level.Equals(2))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en2.Name, "HP : " + en2.HP + "/" + en2.Max_HP, "공격력 : " + en2.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en2.Basic());
                                }
                                else if (sys.level.Equals(3))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en3.Name, "HP : " + en3.HP + "/" + en3.Max_HP, "공격력 : " + en3.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en3.Basic());
                                }else if (sys.level.Equals(4))
                                {
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en4.Name, "HP : " + en4.HP + "/" + en4.Max_HP, "공격력 : " + en4.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en4.Basic());
                                }
                                else
                                {
                                    Console.WriteLine("오류 끄고 다시 켜주세요");
                                }
                                    continue;
                            }
                            // 입력한 값이 1-공격, 2-패링, 3-스킬, 4-회복 중 하나인지를 확인
                            if (sys.battle_choice == 1 || sys.battle_choice == 2 || sys.battle_choice == 3 || sys.battle_choice == 4)
                            {
                                if (sys.level.Equals(1))
                                {
                                    sys.isKill = play.Player_Attack(en1, sys.battle_choice, ref sys.Padding, ref sys.isKill);
                                    if (sys.isKill.Equals(false))
                                    {
                                        sys.isDead = play.Player_Hurt(en1, ref sys.Padding, ref sys.isKill);
                                    }
                                }
                                else if (sys.level.Equals(2))
                                {
                                    sys.isKill = play.Player_Attack(en2, sys.battle_choice, ref sys.Padding, ref sys.isKill);
                                    if (sys.isKill.Equals(false))
                                    {
                                        sys.isDead = play.Player_Hurt(en2, ref sys.Padding, ref sys.isKill);
                                    }
                                }
                                else if (sys.level.Equals(3))
                                {
                                    sys.isKill = play.Player_Attack(en3, sys.battle_choice, ref sys.Padding, ref sys.isKill);
                                    if (sys.isKill.Equals(false))
                                    {
                                        sys.isDead = play.Player_Hurt(en3, ref sys.Padding, ref sys.isKill);
                                    }
                                }
                                else if (sys.level.Equals(4))
                                {
                                    sys.isKill = play.Player_Attack(en4, sys.battle_choice, ref sys.Padding, ref sys.isKill);
                                    if (sys.isKill.Equals(false))
                                    {
                                        sys.isDead = play.Player_Hurt(en4, ref sys.Padding, ref sys.isKill);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("오류 끄고 다시 켜주세요");
                                }

                                break;
                            }
                            else
                            {
                                // 잘못된 숫자 입력 처리
                                Console.Clear();
                                if (sys.level.Equals(1))
                                {
                                    Console.WriteLine("\n                                                                Level  :  " + sys.level);
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] { en1.Name, "HP : " + en1.HP + "/" + en1.Max_HP, "공격력 : " + en1.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en1.Basic());
                                }
                                else if (sys.level.Equals(2))
                                {
                                    Console.WriteLine("\n                                                                Level  :  " + sys.level);
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] {  en2.Name, "HP : " + en2.HP + "/" + en2.Max_HP, "공격력 : " + en2.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en2.Basic());
                                }
                                else if (sys.level.Equals(3))
                                {
                                    Console.WriteLine("\n                                                                Level  :  " + sys.level);
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] {  en3.Name, "HP : " + en3.HP + "/" + en3.Max_HP, "공격력 : " + en3.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en3.Basic());
                                }
                                else if (sys.level.Equals(4))
                                {
                                    Console.WriteLine("\n                                                                Level  :  " + sys.level);
                                    menu.PrintText(new string[] {play.Name,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage,
                                                    "회복력 : " + play.Recover }, new string[] {  en4.Name, "HP : " + en4.HP + "/" + en4.Max_HP, "공격력 : " + en4.Attack_Power }, 1, 1);
                                    Console.WriteLine("\n|-------------------------------------------------");
                                    Painting(play.Basic(), en4.Basic());
                                }
                                else { 
                                }
                            }
                        }
                        if (sys.isKill)
                        {
                            sys.battle = false;
                            sys.total_GameEnd = false;
                            sys.print($"{sys.currentEnemy}를 처치하셨습니다. 축하드립니다.");
                            if (sys.level.Equals(1))
                            {
                                sys.print($"{en1.Enemy_Cash} 지오를 획득했습니다.");
                                play.Coin += en1.Enemy_Cash;
                            }
                            else if (sys.level.Equals(2))
                            {
                                sys.print($"{en2.Enemy_Cash} 지오를 획득했습니다.");
                                play.Coin += en2.Enemy_Cash;
                            }
                            else if (sys.level.Equals(3))
                            {
                                sys.print($"{en3.Enemy_Cash} 지오를 획득했습니다.");
                                play.Coin += en3.Enemy_Cash;
                            }
                            else if (sys.level.Equals(4))
                            {
                                sys.print($"{en4.Enemy_Cash} 지오를 획득했습니다.");
                                play.Coin += en4.Enemy_Cash;
                            }
                            else
                            {

                            }
                            play.Player_Levelup();
                            Console.ReadLine();
                            Console.Clear();
                            Painting0(play.Basic());
                            sys.print($"계속해서 모험을 하시겠습니까? 1. 예 2. 성유물의 재단 이동 3. 메뉴로 이동 4. 인벤토리");
                            sys.level++;
                            while (true)
                            {
                                if (!int.TryParse(Console.ReadLine(), out sys.map_choice))
                                {
                                    Console.Clear();
                                    Painting0(play.Basic());
                                    sys.print($"계속해서 모험을 하시겠습니까? 1. 예 2. 성유물의 재단 이동 3. 메뉴로 이동 4. 인벤토리");
                                    continue;
                                }

                                // 입력한 값이 1, 2, 3 중 하나인지를 확인
                                if (sys.map_choice == 1 || sys.map_choice == 2 || sys.map_choice == 3 || sys.map_choice.Equals(4))
                                {
                                    if (sys.map_choice == 1)
                                    {
                                        sys.currentEnemy = en2.Name;
                                        sys.print_conv = true;
                                        sys.shop = false;
                                        sys.battle = true;
                                        Console.Clear();
                                        sys.Loading = false;
                                        sys.Padding = false;
                                        sys.isKill = false;
                                        sys.isAttack = false;
                                        sys.isDead = false;
    }
                                    else if (sys.map_choice == 2)
                                    {
                                        sys.shop = true;
                                        sys.battle = false;
                                        Console.Clear();
                                        sys.Loading = false;
                                        sys.Padding = false;
                                        sys.isKill = false;
                                        sys.isAttack = false;
                                        sys.isDead = false;
                                    }
                                    else if(sys.map_choice.Equals(3))
                                    {
                                        sys.shop = false;
                                        sys.battle = false;
                                        sys.menu = true;
                                        Console.Clear();
                                        sys.Loading = true;
                                        sys.Padding = false;
                                        sys.isKill = false;
                                        sys.isAttack = false;
                                        sys.isDead = false;
                                    }
                                    else
                                    {
                                        sys.shop = false;
                                        sys.battle = false;
                                        sys.menu = true;
                                        sys.Loading = false;
                                        sys.Padding = false;
                                        sys.isKill = false;
                                        sys.isAttack = false;
                                        sys.isDead = false;
                                        sys.inven = true;
                                    }
                                    break;
                                }
                                else
                                {
                                    // 잘못된 숫자 입력 처리
                                    Console.Clear();
                                    Painting0(play.Basic());
                                    sys.print($"계속해서 모험을 하시겠습니까? 1. 예 2. 성유물의 재단 이동 3. 메뉴로 이동 4. 인벤토리");
                                }

                            }
                        }
                        else if (sys.isDead)
                        {
                            sys.battle = false;
                            sys.total_GameEnd = true;
                        }
                    }
                    sys.print_conv = true;

                    /* 성유물의 재단 */
                    while (sys.shop)
                    {
                        Painting0(menu.Shop_Protector);
                        if (sys.print_conv)
                        {
                            sys.print("카푸치노. 성유물의 재단에 온 것을 환영합니다");
                            sys.print_conv = false;
                        }
                        sys.print("당신에게 도움이 될 것들이 있습니다. 보시겠습니까?");
                        sys.print("1.네 2. 회복하겠습니다.(MP 소모 X) 3. 나중에 오겠습니다");
                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out sys.shop_choice))
                            {
                                Console.Clear();
                                Painting0(menu.Shop_Protector);
                                sys.print("1.네 2. 회복하겠습니다.(MP 소모 X) 3. 나중에 오겠습니다");
                                sys.print("내가 가진 지오 : " + play.Coin);
                                continue;
                            }

                            if (sys.shop_choice.Equals(1) || sys.shop_choice.Equals(2) || sys.shop_choice.Equals(3))
                            {
                                if (sys.shop_choice.Equals(1))
                                {
                                    while (true)
                                    {
                                        Console.Clear();
                                        sh.Welcome(sys.isHeartExist, sys.isFuryExist);
                                        if (sys.isHeartExist.Equals(true) && sys.isFuryExist.Equals(true))
                                        {
                                            sys.print("1. 생명혈의 핵(500) 2. 전사자의 분노(500) 3. 나간다.");
                                            sys.print("내가 가진 지오 : " + play.Coin);
                                        }
                                        else if(sys.isHeartExist.Equals(false) && sys.isFuryExist.Equals(true))
                                        {
                                            sys.print("2. 전사자의 분노(500) 3. 나간다.");
                                            sys.print("내가 가진 지오  : " + play.Coin);
                                        }
                                        else if (sys.isHeartExist.Equals(true) && sys.isFuryExist.Equals(false))
                                        {
                                            sys.print("1.생명혈의 핵(500) 3. 나간다.");
                                            sys.print("내가 가진 지오 : " + play.Coin);
                                        }
                                        else
                                        {
                                            sys.print("모든 고대 유물들의 활성화에 성공하셨습니다.");
                                            sys.print("3. 나간다.");
                                        }
                                        if (!int.TryParse(Console.ReadLine(), out sys.buy_choice))
                                        {
                                            continue;
                                        }
                                        if (sys.buy_choice.Equals(1) || sys.buy_choice.Equals(2) || sys.buy_choice.Equals(3)) {
                                            if (sys.buy_choice.Equals(1)) {
                                                sys.isHeartExist = sh.shop_Bloo(play);
                                                play.UseItem(sh.Heart.Name);
                                                Console.ReadLine();
                                            }
                                            else if (sys.buy_choice.Equals(2))
                                            {
                                                sys.isFuryExist = sh.shop_Fury(play);
                                                play.UseItem(sh.Fury.Name);
                                                Console.ReadLine();
                                            }
                                            else
                                            {
                                                sys.print("좋은 시간이 되셨으면 좋겠습니다.");
                                                Console.ReadLine();
                                                Console.Clear();
                                                break;
                                            }
                                        }
                                    }

                                }
                                else if (sys.shop_choice.Equals(2))
                                {
                                    Console.Clear();
                                    Painting0(play.RECOVER());
                                    SpacePaint(play.RECOVER());
                                    sys.print($"{play.Name}의 HP : {play.HP}");
                                    SpacePaint(play.RECOVER());
                                    sys.print($"{play.Name}가 최대체력으로 회복합니다.");
                                    SpacePaint(play.RECOVER());
                                    play.HP = play.Max_HP;
                                    sys.print($"{play.Name}의 HP : {play.HP}");
                                    Console.ReadLine();
                                    Console.Clear();

                                }
                                else if (sys.shop_choice.Equals(3))
                                {
                                    sys.total_GameEnd = false;
                                    sys.Loading = true;
                                    sys.shop = false;
                                }
                                break; 
                            }
                            else
                            {
                                Console.Clear();
                                break;
                            }

                        }

                    }
                    while (sys.inven)
                    {
                        Console.WriteLine("                                                     INVENTORY");
                        menu.PrintTextInsideFrame(new string[] {play.Name, "레벨 : "+ play.Level, "경험치 : " + play.Exp +"/"+ play.Levelup,
                                                    "HP : " + play.HP+"/"+play.Max_HP, "MP : "+play.Mp+"/10", "공격력 : " + play.Attack_Power, "스킬 공격력 : " + play.SKDamage, "지오 : " + play.Coin,
                                                    "회복력 : " + play.Recover }, 1, 1);
                        Console.WriteLine();
                        Console.WriteLine();
                        play.show_Inven();
                        sys.print("나가실려면 아무거나 눌러주세요");
                        Console.ReadLine();
                        sys.inven = false;
                        sys.total_GameEnd = false;
                        sys.Loading = true;
                        sys.shop = false;
                        sys.again = true;
                    }

                }
                if (sys.isDead.Equals(true))
                {
                    Console.Clear();
                    Painting0(play.Die());
                    Console.WriteLine("게임에서 지셨습니다. 재도전 하시겠습니까? Y/N");
                    char reset;
                    while (true)
                    {
                        if (!char.TryParse(Console.ReadLine(), out reset))
                        {
                            Console.WriteLine("재입력해주세요");
                            continue;
                        }

                        if (reset.Equals('Y') || reset.Equals('N') || reset.Equals('y') || reset.Equals('n'))
                        {
                            if (reset.Equals('Y') || reset.Equals('y'))
                            {
                                sys.isDead = false;      // 사망 상태를 false로
                                sys.really_End = false;  // 게임 종료 상태를 false로
                                sys.total_GameEnd = false;  // 게임 종료 상태를 false로

                                // 게임을 다시 시작할 때 필요한 상태 초기화
                                sys.currentEnemy = "";
                                sys.battle = false;
                                sys.shop = false;
                                sys.level = 0;
                                sys.map_choice = 0;
                                sys.menu_choice = 0;
                                sys.Padding = false;
                                sys.again = true;
                            }
                            else
                            {
                                sys.isDead = false;
                                sys.really_End = true;
                            }
                            break;
                        }
                        else
                        {
                            Console.WriteLine("다시입력해주세요\n");
                        }

                    }
                    Console.Clear();
                }

            }

        }
        static public void Painting0(string[] play)
        {
            for (int i = 0; i < play.Length; i++)
            {
                Console.WriteLine("                                                                       " + play[i]);

            }
        }
        static public void Painting(string[] play, string[] ene)
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

        static public void PaintingHalfScale(string[] play, string[] ene)
        {
            int maxLines = Math.Max(play.Length, ene.Length) / 2; // 세로 50% 축소
            for (int i = 0; i < maxLines; i++)
            {
                string left = i * 2 < play.Length ? ReduceWidth(play[i * 2]) : "";
                string right = i * 2 < ene.Length ? ReduceWidth(ene[i * 2]) : "";

                Console.WriteLine(left.PadRight(47) + right); // 축소된 결과 출력
            }
        }

        // 가로 50% 축소
        static string ReduceWidth(string input)
        {
            StringBuilder reduced = new StringBuilder();
            for (int j = 0; j < input.Length; j += 2) // 가로 50% 축소
            {
                reduced.Append(input[j]); // 2글자 중 1글자만 선택
            }
            return reduced.ToString();
        }

        static public void Painting4(string[] play, string[] ene)
        {
            int Space = 0;
            int maxLines = Math.Max(play.Length, ene.Length);
            for (int i = 0; i < maxLines; i++)
            {
                if (ene.Length > i && play.Length > i)
                {
                    Console.WriteLine(play[i] + "                " + ene[i]);
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
                    Console.WriteLine("                " + ene[i]);
                }

            }

        }
        static public void SpacePaint(string[] menu_space)
        {
            for (int i = 0; i < menu_space[0].Length / 2; i++)
            {
                Console.Write(" ");
            }
        }
        static public void ArrPaint(string[] menu_arr)
        {
            for (int i = 0; i < menu_arr.Length; i++)
            {
                Console.WriteLine(menu_arr[i]);
            }
        }


    }
}


namespace SpartaDeongeon_LIK
{
    internal class Program
    {
        public static void Input()
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">> ");
            string behavior = Console.ReadLine();

            switch (behavior)
            {
                case "1":
                    Character.Status();
                    break;
                case "2":
                    Character.Inventory();
                    break;
                case "3":
                    Character.Shop();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    System.Threading.Thread.Sleep(2000);
                    Input();
                    break;
            }
        }
        class Character
        {
            public static int level = 01;
            public static string name;
            public static string chad = "전사";
            public static int attack = 10;
            public static int defense = 5;
            public static int defenseUp = 0;
            public static int health = 100;
            public static int gold = 15000;
            public static string[,] inventory = new string[3, 10];
            public static string[,] item = {
                { "수련자 갑옷","\t| " , "방어력","+", "5","\t| ", "수련에 도움을 주는 갑옷입니다.","\t| ", "1000","G" },
                { "무쇠갑옷","\t| " , "방어력","+", "9","\t| ", "무쇠로 만들어져 튼튼한 갑옷입니다.","\t| ", "2000","G" },
                {"스파르타의 갑옷","\t| " , "방어력","+", "15","\t| ","스파르타의 전사들이 사용했다는 전설의 갑옷입니다.","\t| ","3000","G" }
            };

            public Character()
            {
                name = "Unknown";               
            }
            
            public Character(string newName)
            {
                name = newName;               
            }

            public static void Status()
            {   
                Console.Clear();
                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine("");
                Console.WriteLine("이 름 : " + name);
                Console.WriteLine("Lv. " + level);
                Console.WriteLine("Chad ( " + chad + " )");
                Console.WriteLine("공격력 : " + attack);                
                if (defenseUp != 0)
                {
                    Console.WriteLine("방어력 : " + (defense + defenseUp) + " (+" + defenseUp + ")");
                }
                else
                {
                    Console.WriteLine("방어력 : " + (defense + defenseUp));
                }
                Console.WriteLine("체 력 : " + health);
                Console.WriteLine("Gold : " + gold + " G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string behavior = Console.ReadLine();

                if (behavior == "0")
                {
                    Input();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    System.Threading.Thread.Sleep(2000);
                    Status();
                }
            }

            public static void Inventory()
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
               
                for (int i = 0; i < inventory.GetLength(0); i++)
                {
                    for (int j = 0; j < inventory.GetLength(1); j++)
                    {
                        Console.Write(inventory[i, j]);
                    }
                    Console.WriteLine();
                }
                
                Console.WriteLine();
                Console.WriteLine("1. 장착 관리");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string behavior = Console.ReadLine();

                if (behavior == "0")
                {
                    Input();
                }
                else if (behavior == "1")
                {
                    Management();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    System.Threading.Thread.Sleep(2000);
                    Inventory();
                }
            }

            public static void Management()
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                
                for (int i = 0; i < inventory.GetLength(0); i++)
                {
                    Console.Write("- " + (i + 1) + " ");
                    for (int j = 0; j < inventory.GetLength(1); j++)
                    {
                        Console.Write(inventory[i, j]);
                    }
                    Console.WriteLine();
                }
                
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string behavior = Console.ReadLine();

                if (behavior == "0")
                {
                    Input();
                }
                else if (behavior == "1")
                {
                    if (inventory[0, 0] == null)
                    {
                        Console.WriteLine("해당 아이템이 존재하지 않습니다.");
                    }
                    else if (inventory[0, 0].Substring(0, 3) == "[E]") 
                    {
                        Console.WriteLine(inventory[0, 0].Substring(3) + "을(를) 해제했습니다.");
                        inventory[0, 0] = inventory[0, 0].Substring(3);
                        defenseUp -= int.Parse(inventory[0, 4]);
                    }
                    else
                    {
                        Console.WriteLine(inventory[0, 0] + "을(를) 장착했습니다.");
                        inventory[0, 0] = "[E]" + inventory[0, 0];
                        defenseUp += int.Parse(inventory[0, 4]);
                    }
                    System.Threading.Thread.Sleep(2000);
                    Management();
                }
                else if (behavior == "2")
                {
                    if (inventory[1, 0] == null)
                    {
                        Console.WriteLine("해당 아이템이 존재하지 않습니다.");
                    }
                    else if (inventory[1, 0].Substring(0, 3) == "[E]") 
                    {
                        Console.WriteLine(inventory[1, 0].Substring(3) + "을(를) 해제했습니다.");
                        inventory[1, 0] = inventory[1, 0].Substring(3);
                        defenseUp -= int.Parse(inventory[1, 4]);
                    }
                    else
                    {
                        Console.WriteLine(inventory[1, 0] + "을(를) 장착했습니다.");
                        inventory[1, 0] = "[E]" + inventory[1, 0];
                        defenseUp += int.Parse(inventory[1, 4]);
                    }
                    System.Threading.Thread.Sleep(2000);
                    Management();
                }
                else if (behavior == "3")
                {
                    if (inventory[2, 0] == null)
                    {
                        Console.WriteLine("해당 아이템이 존재하지 않습니다.");
                    }
                    else if (inventory[2, 0].Substring(0, 3) == "[E]") 
                    {
                        Console.WriteLine(inventory[2, 0].Substring(3) + "을(를) 해제했습니다.");
                        inventory[2, 0] = inventory[2, 0].Substring(3);
                        defenseUp -= int.Parse(inventory[2, 4]);
                    }
                    else
                    {
                        Console.WriteLine(inventory[2, 0] + "을(를) 장착했습니다.");
                        inventory[2, 0] = "[E]" + inventory[2, 0];
                        defenseUp += int.Parse(inventory[2, 4]);
                    }
                    System.Threading.Thread.Sleep(2000);
                    Management();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    System.Threading.Thread.Sleep(2000);
                    Management();
                }
            }

            public static void Shop()
            {
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{gold} G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < item.GetLength(0); i++)
                {
                    for (int j = 0; j < item.GetLength(1); j++)
                    {
                        Console.Write(item[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("1. 아이템 구매");
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string behavior = Console.ReadLine();

                if (behavior == "0")
                {
                    Input();
                }
                else if (behavior == "1")
                {
                    Perchase();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    System.Threading.Thread.Sleep(2000);
                    Shop();
                }
            }

            public static void Perchase()
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine();
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{gold} G");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < item.GetLength(0); i++)
                {
                    Console.Write("- " + (i + 1) + " ");
                    for (int j = 0; j < item.GetLength(1); j++)
                    {
                        Console.Write(item[i, j]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">> ");
                string behavior = Console.ReadLine();

                if (behavior == "0")
                {
                    Input();
                }
                else if (behavior == "1")
                {
                    if (item[0, 8] == "구매완료")
                    {
                        Console.WriteLine("이미 구매하신 항목입니다.");
                    }
                    else if (gold > int.Parse(item[0, 8]))
                    {
                        Console.WriteLine("구매를 완료했습니다.");

                        gold -= int.Parse(item[0, 8]);
                        for (int j = 0; j < item.GetLength(1); j++)
                        {
                            inventory[0, j] = item[0, j];
                        }
                        item[0, 8] = "구매완료";
                        item[0, 9] = null;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                    }
                    System.Threading.Thread.Sleep(2000);
                    Perchase();
                }
                else if (behavior == "2")
                {
                    if (item[1, 8] == "구매완료")
                    {
                        Console.WriteLine("이미 구매하신 항목입니다.");
                    }
                    else if (gold > int.Parse(item[1, 8]))
                    {
                        Console.WriteLine("구매를 완료했습니다.");

                        gold -= int.Parse(item[1, 8]);
                        for (int j = 0; j < item.GetLength(1); j++)
                        {
                            inventory[1, j] = item[1, j];
                        }
                        item[1, 8] = "구매완료";
                        item[1, 9] = null;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                    }
                    System.Threading.Thread.Sleep(2000);
                    Perchase(); 
                }
                else if (behavior == "3")
                {
                    if (item[2, 8] == "구매완료")
                    {
                        Console.WriteLine("이미 구매하신 항목입니다.");
                    }
                    else if (gold > int.Parse(item[2, 8]))
                    {
                        Console.WriteLine("구매를 완료했습니다.");

                        gold -= int.Parse(item[2, 8]);
                        for (int j = 0; j < item.GetLength(1); j++)
                        {
                            inventory[2, j] = item[2, j];
                        }
                        item[2, 8] = "구매완료";
                        item[2, 9] = null;
                    }
                    else
                    {
                        Console.WriteLine("Gold가 부족합니다.");
                    }
                    System.Threading.Thread.Sleep(2000);
                    Perchase(); 
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    System.Threading.Thread.Sleep(2000);
                    Perchase();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("캐릭터를 생성합니다.");
            Console.WriteLine("닉네임을 설정해 주세요.");
            Console.Write(">> ");
            string nickName = Console.ReadLine();

            Character character = new Character(nickName);

            Input();            
        }
    }
}
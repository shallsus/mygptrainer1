using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PJ1_LAST_START
{
    public enum State
    {
        IDLE,
        ATTACK,
        Die,
        PADDING,
        Skill,
        Recover
    }
 
    public interface IAttack
    {
        string[] Attack();
    }
    public interface IDie
    {
        string[] Die();
    }
    public interface IBasic
    {
        string[] Basic();
    }
    public interface IFlip
    {
        string[] Flip(string[] anim);
    }



    public class Creature : IAttack, IDie, IBasic, IFlip
    {
        protected string _Name;
        protected int _Attack_Power;
        protected int _Hp;
        protected int _Enemy_Exp;
        protected int _Enemy_Cash;


        protected List<string[]> Animation = new List<string[]>();
        protected int _MAX_HP;
        public string Name { get { return _Name; } protected set { _Name = value; } }
        public int Attack_Power { get { return _Attack_Power; } set { _Attack_Power = value; } }
        public int HP { get { return _Hp; } set { _Hp = value; } }
        public int Enemy_Exp { get { return _Enemy_Exp; } set { _Enemy_Exp = value; } }
        
        public int Max_HP {get { return _MAX_HP; } set { _MAX_HP = value; } }
        public int Enemy_Cash { get { return _Enemy_Cash; } set { _Enemy_Cash = value; } }
        public string[] Basic()
        {
            return Animation[(int)State.IDLE];
        }
        public string[] Attack()
        {
            return Animation[(int)State.ATTACK];
        }
        public string[] Die()
        {
            return Animation[(int)State.Die];
        }



        public string[] Flip(string[] anim)
        {
            int distance = anim[0].Length;
            char temp;


            for (int j = 0; j < anim.Length; j++)
            {
                // 현재 애니메이션 문자열을 char 배열로 변환 //string은 불변이라서 못 바꿈
                char[] animChars = anim[j].ToCharArray();

        
                for (int i = 0; i < distance / 2; i++)
                {
                    // 두 문자 교환
                    temp = animChars[distance - i - 1];
                    animChars[distance - i - 1] = animChars[i];  
                    animChars[i] = temp; 
                }

               
                anim[j] = new string(animChars);
            }

            return anim;
        }
        public void print(string mes)
        {
            foreach (var ch in mes)
            {
                Console.Write(ch);
                Thread.Sleep(10);
            }
            Console.WriteLine();
        }

    }
}

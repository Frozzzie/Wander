using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Screens;

namespace Wanderer.Creatures.Powers
{
    public class PowerVM
    {
        public enum Actions
        {
            LITERAL = 0x00,
            SET_HEALTH = 0x01,
            SET_STAT = 0x02,
            SET_COUNTER = 0x03,
            SET_DELAY = 0x04,
            SET_TARGET = 0x05,

            GET_HEALTH = 0x11,
            GET_STAT = 0x12,
            GET_COUNTER = 0x13,
            GET_DELAY = 0x14,
            GET_TARGET = 0x15,

            MATH_ADD = 0x21,
            MATH_SUBTRACT = 0x22,
            MATH_MULT = 0x23,
            MATH_DIVIDE = 0x24,
            MATH_MAX = 0x25,
            MATH_MIN = 0x26
        };

        private static int MAX_STACK = 128;
        private int stackSize_;
        private int[] stack_ = new int[MAX_STACK];
        private BattleScreen screen_;

        public PowerVM(BattleScreen screen)
        {
            screen_ = screen;
            stackSize_ = 0;
        }

        private void push(int value)
        {
            if (stackSize_ < MAX_STACK)
                stack_[stackSize_++] = value;
        }

        private int pop()
        {
            if (stackSize_ > 0)
                return stack_[--stackSize_];
            else
                return -1;
        }

        private void Suspend(int[] bytes, int loc, int size)
        {
            suspend = true;
            suspendedbytes = bytes;
            suspendedloc = loc;
            susSize = size;
        }

        public void Resume()
        {
            if (!suspend) throw new Exception("Cannot resume an already running VM");
            interpret(suspendedbytes, susSize);
        }

        private int[] suspendedbytes;
        private int suspendedloc;
        private int susSize;
        private bool suspend = false;

        public void interpret(int[] bytecode, int size)
        {
            int[] args = new int[10];
            int i = 0;
            if (suspend)
            {
                i = suspendedloc;
                suspend = false;
                suspendedloc = 0;
                suspendedbytes = null;
                susSize = 0;
            }
            for (; i < size && !suspend; i++)
            {
                int instruction = bytecode[i];
                switch (instruction)
                {
                    case (int)Actions.LITERAL:
                        int v = bytecode[++i];
                        push(v);
                        break;
                    case (int)Actions.SET_HEALTH:
                        int health = pop();
                        int target = pop();
                        int player = pop();
                        SetHealth(player, target, health);
                        break;
                    case (int)Actions.SET_COUNTER:
                    case (int)Actions.SET_DELAY:
                    case (int)Actions.SET_STAT:
                        break;

                    case (int)Actions.GET_HEALTH:
                        int targetH = pop();
                        int playerH = pop();
                        push(GetHealth(playerH, targetH));
                        break;
                    case (int)Actions.GET_COUNTER:
                    case (int)Actions.GET_DELAY:
                    case (int)Actions.GET_STAT:
                        break;
                    case (int)Actions.GET_TARGET:
                        Suspend(bytecode, i, size);
                        args[1] = pop();
                        args[0] = pop();
                        GetTarget(args[1], args[0]);
                        break;
                    case (int)Actions.MATH_ADD:
                        int addb = pop();
                        int adda = pop();
                        push(adda + addb);
                        break;
                    case (int)Actions.MATH_SUBTRACT:
                        int subb = pop();
                        int suba = pop();
                        push(suba - subb);
                        break;
                    case (int)Actions.MATH_MULT:
                        int multb = pop();
                        int multa = pop();
                        push(multa * multb);
                        break;
                    case (int)Actions.MATH_DIVIDE:
                        int divb = pop();
                        int diva = pop();
                        push(diva / divb);
                        break;
                    case (int)Actions.MATH_MIN:
                        int minb = pop();
                        int mina = pop();
                        push(Math.Min(mina, minb));
                        break;
                    case (int)Actions.MATH_MAX:
                        int maxb = pop();
                        int maxa = pop();
                        push(Math.Max(maxa, maxb));
                        break;

                }
            }
        }

        public int GetHealth(int player, int target)
        {
            return 0;
            //return screen_.GetCreature(player, target).CurrentHealth;
        }

        private int GetStat(int player, int target)
        {
            return 0;
        }

        private int GetCounter(int player, int target, int counter)
        {
            return 0;
        }

        private int GetDelay(int player, int target)
        {
            return 0;
        }

        private Tuple<int, int> GetTarget(int friendly, int numTargets) // 0 is friendly, 1 is enemy, 2 is either
        {
            Tuple<int, int> t = new Tuple<int, int>(0, 0);
            //t = screen_.GetTarget(player, friendly, numTargets);
            return t;
        }

        public void SetHealth(int player, int target, int health)
        {
            //screen_.GetCreature(player, target).SetCurrentHealth(health);
        }

        private void SetStat(int player, int target, int stat, int setTo)
        {           
        }

        private void SetCounter(int player, int target, int counter, int setTo)
        {
        }

        private void SetDelay(int player, int target, int delay)
        {
            
        }

    }
}

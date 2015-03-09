using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;
using Wanderer.Creatures.Powers;


namespace Wanderer.BattleInterfaces
{
    class ConsoleInterface : BattleInterface
    {

        public ConsoleInterface()
        {

        }

        public override void Begin(Wanderer.GameComponents.BattleComponents.Battle battle)
        {
            battle_ = battle;

            battle_.AddCreature(Test.TestCreatures.HardCodeHero(), 1);
            battle_.AddCreature(Test.TestCreatures.HardCodeSnake(), 2);
            battle_.AddCreature(Test.TestCreatures.HardCodeSnake(), 2);
            battle_.AddCreature(Test.TestCreatures.HardCodeSnake(), 2);
            battle_.FirstTurn();
            Console.WriteLine("Battle Begin");
            ShowAllCreatures(0);
            Console.ReadLine();
            BattleLoop();
        }

        private void ShowAllPowers(Creature c)
        {
            for (int i = 0; i < c.Powers.Count; i++)
            {
                Console.WriteLine("{0,2} - {1,20}", i + 1, c.Powers[i].PowerName);
            }
        }

        private Power SelectPower(Creature c)
        {
            Console.WriteLine("Select Power");
            ShowAllPowers(c);
            string input = Console.ReadLine();
            int selection;
            int.TryParse(input, out selection);
            selection--;
            return c.Powers[selection];
        }

        private void BattleLoop()
        {
            List<Creature> left = battle_.GetLeftPlayerCreatures();
            List<Creature> right = battle_.GetRightPlayerCreatures();
            while (!battle_.IsOver())
            {
                ShowAllCreatures(0);
                Creature c = battle_.GetCurrentTurnCreature();
                Console.WriteLine("It is {0}'s turn", c.Name);
                if (left.Contains(c))
                {
                    Power spower = SelectPower(c);
                    for (int i = 0; i < spower.NumTargets; i++)
                    {
                        Creature targ = SelectEnemyCreature();
                        if (targ.IsDead)
                        {
                            i--;
                            Console.WriteLine();
                            Console.WriteLine("Cannot select dead target");
                            continue;
                        }
                        TargetingInformation t = new TargetingInformation(targ, false);
                        spower.Activate(new List<TargetingInformation>() { t });
                    }
                }
                if (right.Contains(c))
                {
                    if (left[0] != null)
                    {
                        TargetingInformation t = new TargetingInformation(left[0], false);
                        Power spower = c.Powers[0]; // this is terrible
                        spower.ActivateScript(new List<TargetingInformation>() { t });
                    }
                }
                battle_.EndOfTurn();
                Console.ReadLine();
            }
        }

        private Creature SelectEnemyCreature()
        {
            ShowAllCreatures(2);
            string cInput = Console.ReadLine(); // creature number
            int c;
            Int32.TryParse(cInput, out c);
            return battle_.GetRightPlayerCreatures()[c - 1]; // 1 based selection for 0-based index.
        }


        private void ShowAllCreatures(int player) // 0 = both, 1 = left, 2 = right
        {
            List<Creature> left;
            List<Creature> right;
            if (player == 0)
            {
                left = battle_.GetLeftPlayerCreatures();
                right = battle_.GetRightPlayerCreatures();
                Console.WriteLine("{0, -16} {1, 0} {2, 16}", "Player", " ", "Enemy");
                for (int i = 0; i < Math.Max(left.Count, right.Count); i++)
                {
                    string sleft = "";
                    string sright = "";
                    if (i < left.Count)
                    {
                        sleft = left[i].Name;
                        if (left[i].CurrentHealth <= 0)
                            sleft = "[X] " + sleft;
                    }
                    if (i < right.Count)
                    {
                        sright = right[i].Name;
                        if (right[i].CurrentHealth <= 0)
                            sright = "[X] " + sright;
                    }

                    
                    Console.WriteLine("{3, -2} {0, -13} {1, 0} {2, 16}", sleft, ":", sright, i + 1);
                }
            }
            if (player == 1)
            {
                left = battle_.GetLeftPlayerCreatures();
                Console.WriteLine("Player Creatures:");
                for (int i = 0; i < left.Count; i++)
                    Console.WriteLine("{0, -2} {1, -13}", i + 1, left[i].Name);
            }
            if (player == 2)
            {
                right = battle_.GetRightPlayerCreatures();
                Console.WriteLine("Enemy Creatures:");
                for (int i = 0; i < right.Count; i++)
                    Console.WriteLine("{0, -2} {1, -13}", i + 1, right[i].Name);
            }
        }
    }
}

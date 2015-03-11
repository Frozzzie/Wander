using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wanderer.Creatures;
using Wanderer.Creatures.Powers;
using Wanderer.EntityEngine;

namespace Wanderer.GameComponents.BattleComponents
{
    class Battle : IGameEntity
    {

        private List<Creature> playerOne_;
        private List<Creature> playerTwo_;
        private List<Creature> initiativeStack_;

        private Creature hasInitiative_;

        public Battle()
        {
            hasInitiative_ = null;
            playerOne_ = new List<Creature>();
            playerTwo_ = new List<Creature>();
        }

        public int Round { get; private set; }

        public void AddCreature(Creature c, int player)
        {
            if (player == 1)
                playerOne_.Add(c);
            else
                playerTwo_.Add(c);
        }

        public void FirstTurn()
        {
            initiativeStack_ = new List<Creature>();
            initiativeStack_.AddRange(playerOne_);
            initiativeStack_.AddRange(playerTwo_);
            foreach (Creature c in initiativeStack_)
            {
                c.ApplyInitiative();
            }
            initiativeStack_.Sort();
            Round++;
            hasInitiative_ = initiativeStack_[0];
            hasInitiative_.ResetSpeed();
        }

        public void EndOfTurn()
        {
            // someone has just done their move.
            foreach (Creature c in initiativeStack_)
                if (c.IsDead) 
                    c.ResetSpeed();
                else
                    c.IncrementSpeed();

            initiativeStack_.Sort();
            hasInitiative_ = initiativeStack_[0];
            hasInitiative_.ResetSpeed();
            Round++;

            //hasInitiative_.ApplyCounters();
        }

        public List<Creature> GetLeftPlayerCreatures()
        {
            //return playerOne_.Where(x => x.CurrentHealth > 0).ToList();
            return playerOne_;
        }

        public List<Creature> GetRightPlayerCreatures()
        {
            //return playerTwo_.Where(x => x.CurrentHealth > 0).ToList();
            return playerTwo_;
        }

        public Creature GetCurrentTurnCreature()
        {
            return hasInitiative_;
        }

        public bool IsOver()
        {
            bool playeronelost = true;
            foreach (Creature c in playerOne_)
            {
                if (!c.IsDead)
                    playeronelost = false;
            }

            bool playertwolost = true;
            foreach (Creature c in playerTwo_)
            {
                if (!c.IsDead)
                    playertwolost = false;
            }

            // set the winner, if any

            return playeronelost || playertwolost;
        }

        public void DamageCreature(Creature c, int damage)
        {
            c.SetCurrentHealth(c.CurrentHealth - damage);
        }


        public IDictionary<string, IDataHolder> Children
        {
            get { 
                var results = new Dictionary<string, IDataHolder>();
                foreach (var c in playerOne_)
                    results.Add(c.Name, c as IDataHolder);
                foreach (var c in playerTwo_)
                    results.Add(c.Name, c as IDataHolder);
                return results;
            }
        }

        public object Data
        {
            get { throw new NotImplementedException(); }
        }

        public int ID
        {
            get { throw new NotImplementedException(); }
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        IDictionary<int, IDataHolder> IDataHolder.Children
        {
            get { throw new NotImplementedException(); }
        }
    }
}

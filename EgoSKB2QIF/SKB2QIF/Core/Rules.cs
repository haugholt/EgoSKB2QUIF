using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SKB2QIF.Core
{
    class Rules
    {
        private List<string> rules;

        public Rules(List<string> rules)
        {
            // TODO: Complete member initialization
            this.rules = rules;
        }

        internal string FindPayee(string p)
        {
            foreach (RuleItem ruleItem in this.Items)
            {
                if (ruleItem.Match(p)) return ruleItem.Payee;
            }
            return "Unknown";
            //return p.ToLower().Contains("meny") ? "Meny" : "Unknown";
        }

        private class RuleItem {
            private string category;
            private string expression;

            public RuleItem(string payee, string category, string expression)
            {
                // TODO: Complete member initialization
                this.Payee = payee;
                this.category = category;
                this.expression = expression;
            }

            public string Payee { get; private set; }

            internal bool Match(string p)
            {
                return p.ToLower().Contains(expression.ToLower());
                
            }
        }

        private IEnumerable<RuleItem> Items { 
            get{
                foreach (string line in rules)
                {
                    var sl= line.Split(new char[]{';'});
                    yield return new RuleItem(sl[0], sl[1], sl[2]);
                }
            }  
        }
    }
}

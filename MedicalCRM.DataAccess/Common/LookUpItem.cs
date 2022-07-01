using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Common {
    public class LookUpItem<TKey, TValue> {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public LookUpItem (TKey key, TValue value) {
            Key = key;
            Value = value;
        }
    }
}

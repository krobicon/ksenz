using System.Text;
using System.Text.Json.Serialization;
using ksenz.Core;
using ksenz.Core.Extensions;
using ksenz.Core.Types;
using ksenz.Driver.Interfaces;
using ksenz.Game.Apex.Core.Interfaces;

namespace ksenz.Game.Apex.Core.Models
{
    public class LevelName : IUpdatable
    {
        private readonly Access<string> _value;

        #region Constructors

        public LevelName(IDriver driver, IOffsets offsets, ulong address)
        {
            _value = driver.Access(address + offsets.CoreLevelName, new StringType(32, Encoding.ASCII), 5000);
        }

        #endregion

        #region Properties

        [JsonPropertyName("value")]
        public string Value => _value.Get();

        #endregion

        #region Implementation of IUpdatable

        public void Update(DateTime frameTime)
        {
            _value.Update(frameTime);
        }

        #endregion
    }
}
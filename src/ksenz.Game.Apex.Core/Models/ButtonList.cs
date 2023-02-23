using System.Text.Json.Serialization;
using ksenz.Core;
using ksenz.Core.Extensions;
using ksenz.Core.Types;
using ksenz.Driver.Interfaces;
using ksenz.Game.Apex.Core.Interfaces;

namespace ksenz.Game.Apex.Core.Models
{
    public class ButtonList : IUpdatable
    {
        private readonly Access<byte> _inAttack;
        private readonly Access<byte> _inWalk;
        private readonly Access<byte> _inZoom;

        #region Constructors

        public ButtonList(IDriver driver, IOffsets offsets, ulong address)
        {
            _inAttack = driver.Access(address + offsets.ButtonInAttack, ByteType.Instance);
            _inWalk = driver.Access(address + offsets.ButtonInWalk, ByteType.Instance);
            _inZoom = driver.Access(address + offsets.ButtonInZoom, ByteType.Instance);
        }

        #endregion

        #region Properties

        [JsonPropertyName("inAttack")]
        public byte InAttack
        {
            get => _inAttack.Get();
            set => _inAttack.Set(value);
        }
        
        [JsonPropertyName("inWalk")]
        public byte InWalk
        {
            get => _inWalk.Get();
            set => _inWalk.Set(value);
        }

        [JsonPropertyName("inZoom")]
        public byte InZoom
        {
            get => _inZoom.Get();
            set => _inZoom.Set(value);
        }
       

        #endregion

        #region Implementation of IUpdatable

        public void Update(DateTime frameTime)
        {
            _inAttack.Update(frameTime);
            _inWalk.Update(frameTime);
            _inZoom.Update(frameTime);
        }

        #endregion
    }
}

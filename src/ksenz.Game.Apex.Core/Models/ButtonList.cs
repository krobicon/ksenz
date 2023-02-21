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
        private readonly Access<byte> _inSpeed;
        private readonly Access<byte> _inWalk;
        private readonly Access<byte> _inZoom;
        private readonly Access<uint> _inForwardDown1;

        #region Constructors

        public ButtonList(IDriver driver, IOffsets offsets, ulong address)
        {
            _inAttack = driver.Access(address + offsets.ButtonInAttack, ByteType.Instance);
            _inSpeed = driver.Access(address + offsets.ButtonInSpeed, ByteType.Instance);
            _inWalk = driver.Access(address + offsets.ButtonInWalk, ByteType.Instance);
            _inZoom = driver.Access(address + offsets.ButtonInZoom, ByteType.Instance);
            _inForwardDown1 = driver.Access(address + offsets.ButtonInForwardDown1, UInt32Type.Instance);
            _inForwardDown2 = driver.Access(address + offsets.ButtonInForwardDown2, UInt32Type.Instance);
            _inForwardState = driver.Access(address + offsets.ButtonInForwardState, UInt32Type.Instance);
        }

        #endregion

        #region Properties

        [JsonPropertyName("inAttack")]
        public byte InAttack
        {
            get => _inAttack.Get();
            set => _inAttack.Set(value);
        }

        [JsonPropertyName("inSpeed")]
        public byte InSpeed
        {
            get => _inSpeed.Get();
            set => _inSpeed.Set(value);
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
        
        [JsonPropertyName("inForwardDown1")]
        public uint InForward
        {
            get => _inForwardDown1.Get();
            set => _inForwardDown1.Set(value);
        }
        
        [JsonPropertyName("inForwardDown2")]
        public uint InForward
        {
            get => _inForwardDown1.Get();
            set => _inForwardDown1.Set(value);
        }
        
        [JsonPropertyName("inForwardState")]
        public uint InForward
        {
            get => _inForwardDown1.Get();
            set => _inForwardDown1.Set(value);
        }

        #endregion

        #region Implementation of IUpdatable

        public void Update(DateTime frameTime)
        {
            _inAttack.Update(frameTime);
            _inSpeed.Update(frameTime);
            _inWalk.Update(frameTime);
            _inZoom.Update(frameTime);
            _inForwardDown1.Update(frameTime);
            _inForwardDown2.Update(frameTime);
            _inForwardState.Update(frameTime);
        }

        #endregion
    }
}

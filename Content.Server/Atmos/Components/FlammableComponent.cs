using Content.Shared.Damage;
using Robust.Shared.Physics.Collision.Shapes;

namespace Content.Server.Atmos.Components
{
    [RegisterComponent]
    public sealed partial class FlammableComponent : Component
    {
        [DataField]
        public bool Resisting;

        [ViewVariables(VVAccess.ReadWrite)]
        [DataField]
        public bool OnFire { get; set; }

        [ViewVariables(VVAccess.ReadWrite)]
        [DataField]
        public float FireStacks { get; set; }

        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("fireSpread")]
        public bool FireSpread { get; private set; } = false;

        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("canResistFire")]
        public bool CanResistFire { get; private set; } = false;

        [DataField("damage", required: true)]
        [ViewVariables(VVAccess.ReadWrite)]
        public DamageSpecifier Damage = new(); // Empty by default, we don't want any funny NREs.

        /// <summary>
        ///     Used for the fixture created to handle passing firestacks when two flammable objects collide.
        /// </summary>
        [DataField("flammableCollisionShape")]
        public IPhysShape FlammableCollisionShape = new PhysShapeCircle(0.35f);

        /// <summary>
        ///     Should the component be set on fire by interactions with isHot entities
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("alwaysCombustible")]
        public bool AlwaysCombustible = false;

        /// <summary>
        ///     Can the component anyhow lose its FireStacks?
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("canExtinguish")]
        public bool CanExtinguish = true;

        /// <summary>
        ///     How many firestacks should be applied to component when being set on fire?
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        [DataField("firestacksOnIgnite")]
        public float FirestacksOnIgnite = 2.0f;

        /// <summary>
        /// Determines how quickly the object will fade out. With positive values, the object will flare up instead of going out.
        /// </summary>
        [DataField, ViewVariables(VVAccess.ReadWrite)]
        public float FirestackFade = -0.1f;

        /// <summary>
        /// Set FirestackFade on Ingite to this value
        /// </summary>
        [DataField]
        public float? FirestackFadeOnIgnite = null;

        /// <summary>
        /// CrystallPunk moment
        /// determines how extinction "FirestackFade" will fade out. it can be used to make "parabolas" of object ignition and decay.
        /// </summary>
        [DataField]
        public float FirestackFadeFade = 0;
    }
}

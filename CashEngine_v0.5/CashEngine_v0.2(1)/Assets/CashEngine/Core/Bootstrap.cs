using UnityEngine;namespace CashEngine.Core{public class Bootstrap:MonoBehaviour{void Awake(){ServiceRegistry.Register(new EventBus());ServiceRegistry.Register(new Logger());ServiceRegistry.Get<Logger>().Info("Bootstrap complete");}}}
// Registers EventBus

using UnityEngine;

namespace Assets.N.Fridman.BackgroundInstanceController.Scripts
{
    public class BackgroundInstanceControllerComponent : MonoBehaviour
    {
        [Header("Tags")]
        [Tooltip("Unique Object Tag")]
        [SerializeField] 
        private string created_Tag;
        
        private void Awake()
        {
            GameObject obj = GameObject.FindWithTag(this.created_Tag);
            if (obj != null)
            {
                Destroy(this.gameObject);
            }
            else
            {
                this.gameObject.tag = this.created_Tag;
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}

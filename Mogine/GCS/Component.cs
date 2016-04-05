namespace Mogine.GCS
{
    public class Component
    {
        public GameObject GameObject;

        private bool _enabled;

        public bool Enabled
        {
            get
            {
                if (GameObject != null)
                {
                    return GameObject.Enabled && _enabled;
                }
                return false;
            }
        }
    }
}
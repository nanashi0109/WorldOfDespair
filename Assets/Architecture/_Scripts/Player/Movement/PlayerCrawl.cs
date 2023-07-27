namespace Despair.Assets.Architecture._Scripts.Player.Movement
{
    public class PlayerCrawl
    {
        private PlayerModel _playerModel;

        public PlayerCrawl(PlayerModel playerModel) 
        {
            _playerModel = playerModel;
        }

        public void Crawl(bool isButtonCrawl) 
        {
            if (isButtonCrawl)
            {
                _playerModel.CrawlCollider.enabled = true;
                _playerModel.CrouchCollider.enabled = false;
                _playerModel.GetPlayerCollider.enabled = false;
            }
            else
            {
                _playerModel.CrawlCollider.enabled = false;
                _playerModel.GetPlayerCollider.enabled = true;
            }
               
        }
    }

}

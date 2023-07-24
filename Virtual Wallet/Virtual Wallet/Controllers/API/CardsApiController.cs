namespace Virtual_Wallet.Controllers.API
{
    [ApiController]
    [Route("api/cards")]
    public class CardsApiController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsApiController(ICardService cardService) 
        {
            this._cardService = cardService;
        }

        [HttpGet("")]
        public IActionResult GetCards() 
        {
            List<Card> cards = this._cardService.GetAll().ToList();
            if (cards.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No cards found!");
            }
            return Ok(cards);
        }
    }
}

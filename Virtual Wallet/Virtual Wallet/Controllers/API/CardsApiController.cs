namespace Virtual_Wallet.Controllers.API
{
    [ApiController]
    [Route("api/cards")]
    public class CardsApiController : ControllerBase
    {
        private readonly ICardService _cardService;
        //private readonly IMapper mapper;

        public CardsApiController(ICardService cardService/*, IMapper mapper*/)
        {
            this._cardService = cardService;
            //this.mapper = mapper;
        }

        [HttpGet("")]
        public IActionResult GetCards()
        {
            List<Card> cards = this._cardService.GetAll().ToList();
            if (cards.Count == 0)
            {
                return StatusCode(StatusCodes.Status204NoContent, "No cards found!");
            }
            List<CardShowDto> result = cards.Select(c => new CardShowDto(c)).ToList();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                Card card = this._cardService.GetById(id);
                CardShowDto result = new CardShowDto(card);
                return Ok(result);

            }
            catch (EntityNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, ex.Message);
            }
        }
    }
}

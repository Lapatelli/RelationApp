using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RelationApp.Core.Entities;
using RelationApp.Core.Interfaces.Services;
using RelationApp.Web.ViewModels;

namespace RelationApp.Web.Controllers
{
    [Route("relations/")]
    [ApiController]
    public class RelationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRelationService _relationService;
        private readonly Random _random;

        public RelationController(IMapper mapper, IRelationService relationService)
        {
            _mapper = mapper;
            _relationService = relationService;

            _random = new Random();
        }

        [HttpGet, Route("")]
        public async Task<IActionResult> GetSortedAllCategoryRelationsAsync([FromQuery] Guid? categoryId, string sortedProp, bool descending)
        {
            var sortedRelations = await _relationService.GetSortedRelationsByCategotyIdAsync(categoryId, sortedProp, descending);

            var resultSortedRelations = _mapper.Map<IEnumerable<Relation>, IEnumerable<GetAllRelationsViewModel>>(sortedRelations);

            return Ok(resultSortedRelations);
        }

        [HttpPost("create")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CreateRelation([FromBody]CreateRelationViewModel createRelationViewModel)
        {
            var randomCategoryLastNumber = _random.Next(1, 8).ToString();
            var randomCategoryId = Guid.Parse($"00000000-0000-0000-0000-00000000000{randomCategoryLastNumber}");

            var relationModel = _mapper.Map<CreateRelationViewModel, Relation>(createRelationViewModel);
            var relationAddressModel = _mapper.Map<(CreateRelationViewModel,Relation), RelationAddress>((createRelationViewModel, relationModel));
            var relationCategoryModel = _mapper.Map<(Relation,Guid), RelationCategory>((relationModel,randomCategoryId));

            var relationAdded = await _relationService.CreateRelationAsync(relationModel, relationAddressModel, relationCategoryModel);

            var entitiesAdded = _mapper.Map<Relation, GetAllRelationsViewModel>(relationAdded);

            return Ok(entitiesAdded);
        }
    }
}
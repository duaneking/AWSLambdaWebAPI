using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LambdaShoppingListWebAPI.Models;
using LambdaShoppingListWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LambdaShoppingListWebAPI.Controllers
{
    [Route("v1/shoppingList")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpGet]
        public IActionResult GetShoppingList()
        {
            var result = _shoppingListService.GetItemsFromShoppingList();
            return Ok(result);
        }   

        [HttpPost]
        public IActionResult AddItemToShoppingList([FromBody]ShoppingListModel shoppingList)
        {
            _shoppingListService.AddItemToShoppingList(shoppingList);
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteItemFromShoppingList([FromBody] ShoppingListModel shoppingList)
        {
            _shoppingListService.RemoveItemFromShoppingList(shoppingList.Name);
            return Ok();
        }
    }
}
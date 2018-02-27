using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace EFCore.InMemoryTest.Demo.UnitTests
{
    public class VoidHeaderServiceShould
    {
        [Fact]
        public void ReturnVoidHeader_WhenValidVoidHeaderIdIsGivenTo_GetVoidHeaderById()
        {
            var voidHeaderId = 123;
            var initialVoidHeaderStatus = 10000;

            var voidHeader = new VoidHeader
            {
                VoidHeaderId = voidHeaderId,
                StatusId = initialVoidHeaderStatus
            };
            
            var dbContextOptionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "GetVoidHeaderById_Test_1");

            var dataContext = new DataContext(dbContextOptionsBuilder.Options);
                        
            dataContext.Add(voidHeader);
            dataContext.SaveChanges();

            var voidHeaderService = new VoidHeaderService(dataContext);

            var result = voidHeaderService.GetVoidHeaderById(voidHeaderId);

            result.Should().NotBeNull();

            result.VoidHeaderId.Should().Be(voidHeaderId);
        }

        [Fact]
        public void InsertVoidHeader_WhenInsertIsCalled_WithValidVoidHeader()
        {
            var voidHeaderId = 123;
            var initialVoidHeaderStatus = 10000;

            var voidHeader = new VoidHeader
            {
                VoidHeaderId = voidHeaderId,
                StatusId = initialVoidHeaderStatus
            };

            var dbContextOptionsBuilder = new DbContextOptionsBuilder()
                .UseInMemoryDatabase(databaseName: "InsertVoidHeader_Test_1");

            var dataContext = new DataContext(dbContextOptionsBuilder.Options);
            
            var voidHeaderService = new VoidHeaderService(dataContext);

            voidHeaderService.Insert(voidHeader);

            var insertedVoidHeader = dataContext.VoidHeader.FirstOrDefault(vh => vh.VoidHeaderId == voidHeaderId);

            insertedVoidHeader.Should().NotBeNull();

            insertedVoidHeader.Should().Be(voidHeader);
        }
    }
}

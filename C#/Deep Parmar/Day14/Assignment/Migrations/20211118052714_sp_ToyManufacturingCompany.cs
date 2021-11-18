using Microsoft.EntityFrameworkCore.Migrations;

namespace Day14.Migrations
{
    public partial class sp_ToyManufacturingCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_ProductList = @"CREATE PROCEDURE sp_ProductList
                                    @ToyName NVARCHAR(MAX)
                                     AS
                                    BEGIN 
                                        SELECT * FROM Toys WHERE ToyName LIKE @ToyName+'%'
                                    END";


            var sp_Order = @"CREATE PROCEDURE sp_order
                                @CustomerId INT,
                                @TotalAmount INT
                                AS
                                BEGIN

                                DECLARE @DATE DATETIME
				                DECLARE @NetAmount INT

                                SET @DATE=GETDATE()

                                DECLARE @DiscountAmount INT

                                IF(@TotalAmount < 500)
                                BEGIN
	                                SET @DiscountAmount=@TotalAmount * 0.05
	                                SET @NetAmount = @TotalAmount-@DiscountAmount
                                END

                                IF(@TotalAmount >= 500)
                                BEGIN
	                                SET @DiscountAmount=@TotalAmount * 0.1
	                                SET @NetAmount = @TotalAmount-@DiscountAmount
                                END

                                INSERT INTO Orders VALUES(@DATE,@TotalAmount,@DiscountAmount,@NetAmount,@CustomerId)

                                END";

            migrationBuilder.Sql(sp_ProductList);

            migrationBuilder.Sql(sp_Order);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var DropProductListSp = "DROP PROCEDURE sp_ProductList";
            var DropOrderSp = "DROP PROCEDURE sp_Order";

            migrationBuilder.Sql(DropProductListSp);
            migrationBuilder.Sql(DropOrderSp);
        }
    }
}

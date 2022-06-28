
DECLARE @supplierId INT;

Select @supplierId = SupplierId From Supplier Where CompanyName = 'Alpina'

IF @supplierId > 0
	BEGIN

		Insert Into Product (
							 ProductName,
							 SupplierId,
							 UnitPrice,
							 IsDiscontinued
							)
					Values	(
								'Avena alpina original',
								@supplierId,
								1900,
								0
							 ),
							 (
								'Kumis alpina',
								@supplierId,
								3000,
								0
							 ),
							 (
								'Leche alpina deslactosada',
								@supplierId,
								4800,
								0
							 )
	END

Select @supplierId = SupplierId From Supplier Where CompanyName = 'Postobón'

IF @supplierId > 0
	BEGIN

		Insert Into Product (
							 ProductName,
							 SupplierId,
							 UnitPrice,
							 IsDiscontinued
							)
					Values	(
								'Gaseosa manzana postobon 2.5 Lts',
								@supplierId,
								5300,
								0
							 ),
							 (
								'Gaseosa uva postobon 2 Lts',
								@supplierId,
								3800,
								0
							 ),
							 (
								'Gaseosa postobon acqua frutos verdes 500 ml',
								@supplierId,
								1900,
								0
							 )
		

	END


						

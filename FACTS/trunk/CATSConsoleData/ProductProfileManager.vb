Public Class ProductProfileManager
	Private _EXISTED_MODEL As CATSConsoleModel.ProductProfile
	Public WriteOnly Property ExistedModel As CATSConsoleModel.ProductProfile
		Set(value As CATSConsoleModel.ProductProfile)
			_EXISTED_MODEL = value
		End Set
	End Property
	''' <summary>
	''' This time,the operation have been switch to destination database,
	''' AND product_mainM comes from destination database
	''' </summary>
	''' <param name="data">Come from source database</param>
	''' <returns>Destination's product_main_id</returns>
	Public Function Create(data As FACTS.Model.product_main) As Integer
		Try

			'If _DES_MODEL.CompareTo(data) = True Then Return _DES_MODEL.product_mainM.id

			Dim pmBll As New FACTS.BLL.product_mainManager
			Dim pmM As FACTS.Model.product_main

			pmM = pmBll.SelectByProductName(data.Product_name)

			'add
			If pmM Is Nothing Then Return pmBll.AddReturnId(data)

			Dim dataId As Integer = data.Id

			data.Id = pmM.id

			'update
			pmBll.Update(data)
			data.Id = dataId

			Return pmM.id

		Catch ex As Exception
			Throw New Exception("ProductProfileManager.Create(product_main)::" & ex.Message)
		End Try
	End Function
	''' <summary>
	''' 
	''' </summary>
	''' <param name="data"></param>
	''' <returns>product_main_id</returns>
	Public Function Create(data As CATSConsoleModel.ProductProfile) As Integer
		Try
			Dim pm_id As Integer
			pm_id = Create(data.product_mainM)

			Return pm_id

		Catch ex As Exception
			Throw New Exception("ProductProfile.Create(ProductProfile)::" & ex.Message)
		End Try
	End Function
End Class

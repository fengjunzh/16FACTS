Imports System
Imports System.Collections.Generic

Public Class product_mainManager

	Private _dal As New FACTS.DAL.product_mainService
	Public Function Add(model As FACTS.Model.product_main) As Boolean
		Try
			Return _dal.Add(model)
		Catch ex As Exception
			Throw New Exception("product_main.BLL.Add()::" & ex.Message)
		End Try
	End Function


	Public Function AddReturnId(model As FACTS.Model.product_main) As Integer
		Try
			Return _dal.AddReturnId(model)
		Catch ex As Exception
			Throw New Exception("product_main.BLL.AddReturnId()::" & ex.Message)
		End Try
	End Function


	Public Function Delete(id As Integer) As Boolean
		Try
			Return _dal.Delete(id)
		Catch ex As Exception
			Throw New Exception("product_main.DAL.Delete()::" & ex.Message)
		End Try
	End Function


	Public Function Update(model As FACTS.Model.product_main) As Boolean
		Try
			Return _dal.Update(model)
		Catch ex As Exception
			Throw New Exception("product_main.BLL.Update()::" & ex.Message)
		End Try
	End Function


	Public Function SelectAll() As List(Of FACTS.Model.product_main)
		Try
			Return _dal.SelectAll()
		Catch ex As Exception
			Throw New Exception("product_main.BLL.SelectAll()::" & ex.Message)
		End Try
	End Function

	Public Function SelectById(id As Integer) As FACTS.Model.product_main
		Try
			Return _dal.SelectById(id)
		Catch ex As Exception
			Throw New Exception("product_main.BLL.SelectById()::" & ex.Message)
		End Try
	End Function

	Public Function SelectByProductName(product_name As String) As FACTS.Model.product_main
		Try
			Return _dal.SelectByProductName(product_name)
		Catch ex As Exception
			Throw New Exception("product_main.BLL.SelectByProductName()::" & ex.Message)
		End Try
	End Function

End Class

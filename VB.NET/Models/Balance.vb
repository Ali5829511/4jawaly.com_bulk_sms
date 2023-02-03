Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace API_Example_VB.Models.Balance
    Public Class Item
        Public Property id As Integer
        Public Property package_points As Integer
        Public Property current_points As Integer
        Public Property expire_at As DateTime
        Public Property account_id As Integer
        Public Property system_uuid As String
        Public Property is_open As Integer
        Public Property ticket_id As Integer?
        Public Property payment_method_id As Integer?
        Public Property bank_id As Integer?
        Public Property price As String
        Public Property tax As String
        Public Property fees As String
        Public Property total As String
        Public Property created_at As DateTime
        Public Property updated_at As DateTime
        Public Property networks As List(Of Network)
        Public Property used_balance As Integer
        Public Property is_completed As Boolean
        Public Property package As Package
    End Class

    Public Class Network
        Public Property id As Integer
        Public Property image As String
        Public Property image_path As String
        Public Property network_tags As List(Of NetworkTag)
    End Class

    Public Class NetworkTag
        Public Property id As Integer
        Public Property image As String
        Public Property title As String
        Public Property network_id As Integer
        Public Property image_path As String
    End Class

    Public Class Package
        Public Property id As Integer
        Public Property title_ar As String
    End Class

    Public Class Balance
        Public Property code As Integer
        Public Property message As String
        Public Property items As List(Of Item)
        Public Property total_balance As Integer
    End Class
End Namespace

﻿'***********************************************************************************************************************
'* Project: CmisObjectModelLibrary
'* Copyright (c) 2014, Brügmann Software GmbH, Papenburg, All rights reserved
'*
'* Contact: opensource<at>patorg.de
'* 
'* CmisObjectModelLibrary is a VB.NET implementation of the Content Management Interoperability Services (CMIS) standard
'*
'* This file is part of CmisObjectModelLibrary.
'* 
'* This library is free software; you can redistribute it and/or
'* modify it under the terms of the GNU Lesser General Public
'* License as published by the Free Software Foundation; either
'* version 3.0 of the License, or (at your option) any later version.
'*
'* This library is distributed in the hope that it will be useful,
'* but WITHOUT ANY WARRANTY; without even the implied warranty of
'* MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
'* Lesser General Public License for more details.
'*
'* You should have received a copy of the GNU Lesser General Public
'* License along with this library (lgpl.txt).
'* If not, see <http://www.gnu.org/licenses/lgpl.txt>.
'***********************************************************************************************************************
Imports CmisObjectModel.Common

'depends on the chosen interpretation of the xs:integer expression in a xsd-file
#If xs_Integer = "Int32" OrElse xs_integer = "Integer" OrElse xs_integer = "Single" Then
Imports xs_Integer = System.Int32
#Else
Imports xs_Integer = System.Int64
#End If

Namespace CmisObjectModel.Messaging
   <Attributes.JavaScriptConverter(GetType(JSON.Messaging.cmisFaultTypeConverter))>
   Partial Class cmisFaultType
   End Class
End Namespace

Namespace CmisObjectModel.JSON.Messaging
   ''' <summary>
   ''' Error handling
   ''' </summary>
   ''' <remarks>see chapter 5.2.10  Error Handling and Return Codes in cmis documentation</remarks>
   Public Class cmisFaultTypeConverter
      Inherits Serialization.Generic.JavaScriptConverter(Of CmisObjectModel.Messaging.cmisFaultType)

#Region "Constructors"
      Public Sub New()
         MyBase.New(New Serialization.Generic.DefaultObjectResolver(Of CmisObjectModel.Messaging.cmisFaultType))
      End Sub
      Public Sub New(objectResolver As Serialization.Generic.ObjectResolver(Of CmisObjectModel.Messaging.cmisFaultType))
         MyBase.New(objectResolver)
      End Sub
#End Region

      Protected Overloads Overrides Sub Deserialize(context As SerializationContext)
         With context
            .Object.Type = ReadEnum(.Dictionary, "exception", .Object.Type)
            .Object.Message = Read(.Dictionary, "message", .Object.Message)
            .Object.Code = Read(.Dictionary, "code", .Object.Code)
            .Object.Extensions = ReadArray(context, "extensions", .Object.Extensions)
         End With
      End Sub

      Protected Overloads Overrides Sub Serialize(context As SerializationContext)
         With context
            .Add("exception", .Object.Type.GetName())
            .Add("message", .Object.Message)
            .Add("code", .Object.Code)
            WriteArray(context, .Object.Extensions, "extensions")
         End With
      End Sub
   End Class
End Namespace
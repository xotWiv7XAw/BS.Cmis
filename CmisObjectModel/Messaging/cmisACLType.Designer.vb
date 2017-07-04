'***********************************************************************************************************************
'* Project: CmisObjectModelLibrary
'* Copyright (c) 2014, Brügmann Software GmbH, Papenburg, All rights reserved
'* Author: auto-generated code
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
Imports sx = System.Xml
Imports sxs = System.Xml.Serialization
'depends on the chosen interpretation of the xs:integer expression in a xsd-file
#If xs_Integer = "Int32" OrElse xs_integer = "Integer" OrElse xs_integer = "Single" Then
Imports xs_Integer = System.Int32
#Else
Imports xs_Integer = System.Int64
#End If

Namespace CmisObjectModel.Messaging
   ''' <summary>
   ''' </summary>
   ''' <remarks>
   ''' see cmisACLType
   ''' in http://docs.oasis-open.org/cmis/CMIS/v1.1/cs01/schema/CMIS-Messaging.xsd
   ''' </remarks>
   Public Class cmisACLType
      Inherits Serialization.XmlSerializable

      Public Sub New()
      End Sub
      ''' <summary>
      ''' this constructor is only used if derived classes from this class needs an InitClass()-call
      ''' </summary>
      ''' <param name="initClassSupported"></param>
      ''' <remarks></remarks>
      Protected Sub New(initClassSupported As Boolean?)
         MyBase.New(initClassSupported)
      End Sub

#Region "IXmlSerializable"
      Private Shared _setter As New Dictionary(Of String, Action(Of cmisACLType, String)) From {
         } '_setter

      ''' <summary>
      ''' Deserialization of all properties stored in attributes
      ''' </summary>
      ''' <param name="reader"></param>
      ''' <remarks></remarks>
      Protected Overrides Sub ReadAttributes(reader As System.Xml.XmlReader)
         'at least one property is serialized in an attribute-value
         If _setter.Count > 0 Then
            For attributeIndex As Integer = 0 To reader.AttributeCount - 1
               reader.MoveToAttribute(attributeIndex)
               'attribute name
               Dim key As String = reader.Name.ToLowerInvariant
               If _setter.ContainsKey(key) Then _setter(key).Invoke(Me, reader.GetAttribute(attributeIndex))
            Next
         End If
      End Sub

      ''' <summary>
      ''' Deserialization of all properties stored in subnodes
      ''' </summary>
      ''' <param name="reader"></param>
      ''' <remarks></remarks>
      Protected Overrides Sub ReadXmlCore(reader As sx.XmlReader, attributeOverrides As Serialization.XmlAttributeOverrides)
         _aCL = Read(Of Core.Security.cmisAccessControlListType)(reader, attributeOverrides, "ACL", Constants.Namespaces.cmism, AddressOf GenericXmlSerializableFactory(Of Core.Security.cmisAccessControlListType))
         _exact = Read(reader, attributeOverrides, "exact", Constants.Namespaces.cmism, _exact)
      End Sub

      ''' <summary>
      ''' Serialization of properties
      ''' </summary>
      ''' <param name="writer"></param>
      ''' <remarks></remarks>
      Protected Overrides Sub WriteXmlCore(writer As sx.XmlWriter, attributeOverrides As Serialization.XmlAttributeOverrides)
         WriteElement(writer, attributeOverrides, "ACL", Constants.Namespaces.cmism, _aCL)
         If _exact.HasValue Then WriteElement(writer, attributeOverrides, "exact", Constants.Namespaces.cmism, Convert(_exact))
      End Sub
#End Region

      Protected _aCL As Core.Security.cmisAccessControlListType
      Public Overridable Property ACL As Core.Security.cmisAccessControlListType
         Get
            Return _aCL
         End Get
         Set(value As Core.Security.cmisAccessControlListType)
            If value IsNot _aCL Then
               Dim oldValue As Core.Security.cmisAccessControlListType = _aCL
               _aCL = value
               OnPropertyChanged("ACL", value, oldValue)
            End If
         End Set
      End Property 'ACL

      Protected _exact As Boolean?
      Public Overridable Property Exact As Boolean?
         Get
            Return _exact
         End Get
         Set(value As Boolean?)
            If Not _exact.Equals(value) Then
               Dim oldValue As Boolean? = _exact
               _exact = value
               OnPropertyChanged("Exact", value, oldValue)
            End If
         End Set
      End Property 'Exact

   End Class
End Namespace
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

Namespace CmisObjectModel.Messaging.Requests
   ''' <summary>
   ''' </summary>
   ''' <remarks>
   ''' see createItem
   ''' in http://docs.oasis-open.org/cmis/CMIS/v1.1/cs01/schema/CMIS-Messaging.xsd
   ''' </remarks>
   <sxs.XmlRoot("createItem", Namespace:=Constants.Namespaces.cmism)>
   Public Class createItem
      Inherits Messaging.Requests.RequestBase

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
      Private Shared _setter As New Dictionary(Of String, Action(Of createItem, String)) From {
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
         _repositoryId = Read(reader, attributeOverrides, "repositoryId", Constants.Namespaces.cmism, _repositoryId)
         _properties = Read(Of Core.Collections.cmisPropertiesType)(reader, attributeOverrides, "properties", Constants.Namespaces.cmism, AddressOf GenericXmlSerializableFactory(Of Core.Collections.cmisPropertiesType))
         _folderId = Read(reader, attributeOverrides, "folderId", Constants.Namespaces.cmism, _folderId)
         _addACEs = Read(Of Core.Security.cmisAccessControlListType)(reader, attributeOverrides, "addACEs", Constants.Namespaces.cmism, AddressOf GenericXmlSerializableFactory(Of Core.Security.cmisAccessControlListType))
         _removeACEs = Read(Of Core.Security.cmisAccessControlListType)(reader, attributeOverrides, "removeACEs", Constants.Namespaces.cmism, AddressOf GenericXmlSerializableFactory(Of Core.Security.cmisAccessControlListType))
         _extension = Read(Of Messaging.cmisExtensionType)(reader, attributeOverrides, "extension", Constants.Namespaces.cmism, AddressOf GenericXmlSerializableFactory(Of Messaging.cmisExtensionType))
      End Sub

      ''' <summary>
      ''' Serialization of properties
      ''' </summary>
      ''' <param name="writer"></param>
      ''' <remarks></remarks>
      Protected Overrides Sub WriteXmlCore(writer As sx.XmlWriter, attributeOverrides As Serialization.XmlAttributeOverrides)
         WriteElement(writer, attributeOverrides, "repositoryId", Constants.Namespaces.cmism, _repositoryId)
         WriteElement(writer, attributeOverrides, "properties", Constants.Namespaces.cmism, _properties)
         If Not String.IsNullOrEmpty(_folderId) Then WriteElement(writer, attributeOverrides, "folderId", Constants.Namespaces.cmism, _folderId)
         WriteElement(writer, attributeOverrides, "addACEs", Constants.Namespaces.cmism, _addACEs)
         WriteElement(writer, attributeOverrides, "removeACEs", Constants.Namespaces.cmism, _removeACEs)
         WriteElement(writer, attributeOverrides, "extension", Constants.Namespaces.cmism, _extension)
      End Sub
#End Region

      Protected _addACEs As Core.Security.cmisAccessControlListType
      Public Overridable Property AddACEs As Core.Security.cmisAccessControlListType
         Get
            Return _addACEs
         End Get
         Set(value As Core.Security.cmisAccessControlListType)
            If value IsNot _addACEs Then
               Dim oldValue As Core.Security.cmisAccessControlListType = _addACEs
               _addACEs = value
               OnPropertyChanged("AddACEs", value, oldValue)
            End If
         End Set
      End Property 'AddACEs

      Protected _extension As Messaging.cmisExtensionType
      Public Overridable Property Extension As Messaging.cmisExtensionType
         Get
            Return _extension
         End Get
         Set(value As Messaging.cmisExtensionType)
            If value IsNot _extension Then
               Dim oldValue As Messaging.cmisExtensionType = _extension
               _extension = value
               OnPropertyChanged("Extension", value, oldValue)
            End If
         End Set
      End Property 'Extension

      Protected _folderId As String
      Public Overridable Property FolderId As String
         Get
            Return _folderId
         End Get
         Set(value As String)
            If _folderId <> value Then
               Dim oldValue As String = _folderId
               _folderId = value
               OnPropertyChanged("FolderId", value, oldValue)
            End If
         End Set
      End Property 'FolderId

      Protected _properties As Core.Collections.cmisPropertiesType
      Public Overridable Property Properties As Core.Collections.cmisPropertiesType
         Get
            Return _properties
         End Get
         Set(value As Core.Collections.cmisPropertiesType)
            If value IsNot _properties Then
               Dim oldValue As Core.Collections.cmisPropertiesType = _properties
               _properties = value
               OnPropertyChanged("Properties", value, oldValue)
            End If
         End Set
      End Property 'Properties

      Protected _removeACEs As Core.Security.cmisAccessControlListType
      Public Overridable Property RemoveACEs As Core.Security.cmisAccessControlListType
         Get
            Return _removeACEs
         End Get
         Set(value As Core.Security.cmisAccessControlListType)
            If value IsNot _removeACEs Then
               Dim oldValue As Core.Security.cmisAccessControlListType = _removeACEs
               _removeACEs = value
               OnPropertyChanged("RemoveACEs", value, oldValue)
            End If
         End Set
      End Property 'RemoveACEs

      Protected _repositoryId As String
      Public Overridable Property RepositoryId As String
         Get
            Return _repositoryId
         End Get
         Set(value As String)
            If _repositoryId <> value Then
               Dim oldValue As String = _repositoryId
               _repositoryId = value
               OnPropertyChanged("RepositoryId", value, oldValue)
            End If
         End Set
      End Property 'RepositoryId

   End Class
End Namespace
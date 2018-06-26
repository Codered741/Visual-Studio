Imports Autodesk.DataManagement.Client.Framework.Vault
Imports Autodesk.Connectivity.WebServices
Imports Autodesk
Imports VDF = Autodesk.DataManagement.Client.Framework
Imports Inventor
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.IO
Imports Microsoft.Office.Interop.Excel
Imports Microsoft.Vbe.Interop
Imports Microsoft.Office.Core
Imports Microsoft.Win32

Namespace TAITInventorAddIn
    <ProgIdAttribute("TAITInventorAddIn.StandardAddInServer"), _
    GuidAttribute("e731e5c3-c035-48de-9158-f8a5510e11b6")> _
    Public Class StandardAddInServer
        Implements Inventor.ApplicationAddInServer

        Public WithEvents M_uiEvents As UserInterfaceEvents
        Public WithEvents BtnAddinInformation As ButtonDefinition
        Public WithEvents BtnMaterialSpec As ButtonDefinition
        Public WithEvents BtnGenerateDwgTree As ButtonDefinition
        Public WithEvents BtnFindDrawings As ButtonDefinition
        Public WithEvents BtnPrintDrawings As ButtonDefinition
        Public WithEvents BtnModifyDwgNotes As ButtonDefinition
        Public WithEvents BtnEngrSpreadsheets As ButtonDefinition
        Public WithEvents BtnBatchChange As ButtonDefinition
        Public WithEvents BtnPropConfig As ButtonDefinition
        Public WithEvents BtnMKDwgRef As ButtonDefinition
        Public WithEvents BtnMKApplyDwgTemplate As ButtonDefinition
        Public WithEvents BtnStdFasteners As ButtonDefinition
        Public WithEvents BtnTestVaultConn As ButtonDefinition
        Public WithEvents BtnKAPPAApplyDwgTemplate As ButtonDefinition
        'The following button definitions are for testing purposes only
        Public ctrlDefs As ObjectCollection
        Public WithEvents _ctrlDef1 As ButtonDefinition
        Public WithEvents _ctrlDef2 As ButtonDefinition
        Public WithEvents _ctrlDef3 As ButtonDefinition
        Public WithEvents BtnDockableForm As ButtonDefinition

        Public WithEvents PropertyConfigForm As frmPropConfig
        Public WithEvents MaterialSpecForm As frmMaterialSpec


#Region "ApplicationAddInServer Members"

        ' This method is called by Inventor when it loads the AddIn. The AddInSiteObject provides access  
        ' to the Inventor Application object. The FirstTime flag indicates if the AddIn is loaded for
        ' the first time. However, with the introduction of the ribbon this argument is always true.
        Public Sub Activate(ByVal addInSiteObject As Inventor.ApplicationAddInSite, ByVal firstTime As Boolean) Implements Inventor.ApplicationAddInServer.Activate
            ' Initialize AddIn members.
            g_inventorApplication = addInSiteObject.Application

            ' Connect to the user-interface events to handle a ribbon reset.
            M_uiEvents = g_inventorApplication.UserInterfaceManager.UserInterfaceEvents

            'Establish control definitions.
            Dim controlDefs As Inventor.ControlDefinitions = g_inventorApplication.CommandManager.ControlDefinitions

            'Create the Add-In info Specification button definition.
            Dim largeinfoIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.info_icon_wZA_icon)
            Dim smallinfoIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.info_icon_wZA_icon)
            BtnAddinInformation = controlDefs.AddButtonDefinition("Add-In Info", "INFO_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Find out more info about the TAIT PI Inventor Add-in.", "Display the version number of the TAIT PI Inventor Add-In.", smallinfoIcon, largeinfoIcon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Material Specification button definition.
            Dim largematerialIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources._164934_200_JQM_icon)
            Dim smallmaterialIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources._164934_200_JQM_icon)
            BtnMaterialSpec = controlDefs.AddButtonDefinition("Edit Material", "M_F_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Generates consistent material names for parts.", "Generate a standard material name for this part", smallmaterialIcon, largematerialIcon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Drawing Tree Gen button definition.
            Dim largetreeIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.tree_K1N_icon)
            Dim smalltreeIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.tree_K1N_icon)
            BtnGenerateDwgTree = controlDefs.AddButtonDefinition("Generate Dwg Tree", "TREE_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Generates a drawing tree for the active assembly document.", "Generate a drawing tree for the open assembly document.", smalltreeIcon, largetreeIcon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Find Drawings button definition.
            Dim largeFindDrawingsIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.finddrawings_jHW_icon)
            Dim smallFindDrawingsIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.finddrawings_jHW_icon)
            BtnFindDrawings = controlDefs.AddButtonDefinition("Find Drawings", "FIND_DWGS_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Generates a drawing status report for the active assembly document.", "Generate a drawing status report of for the open assembly document.", smallFindDrawingsIcon, largeFindDrawingsIcon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Print Drawings button definition.
            Dim largePrintDrawingsIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.printer_SRc_icon)
            Dim smallPrintDrawingsIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.printer_SRc_icon)
            BtnPrintDrawings = controlDefs.AddButtonDefinition("Batch Print" & vbNewLine & "Drawings", "PRINT_DWGS_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Batch prints all drawings for the active assembly document.", "Batch print all drawings for the active assembly document.", smallPrintDrawingsIcon, largePrintDrawingsIcon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Modify Dwg Notes button definition.
            Dim largeModifyDwgNotesicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.noteslist_Upc_icon)
            Dim smallModifyDwgNotesicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.noteslist_Upc_icon)
            BtnModifyDwgNotes = controlDefs.AddButtonDefinition("Modify Notes", "MODIFY_NOTES_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Opens a control to modify drawing notes for the active drawing document.", "Modify drawing notes for the active drawing document.", smallModifyDwgNotesicon, largeModifyDwgNotesicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Engineering Spreadsheets button definition.
            Dim largeOmaticicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.omatic_Wg2_icon)
            Dim smallOmaticicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.omatic_Wg2_icon)
            BtnEngrSpreadsheets = controlDefs.AddButtonDefinition("Engineering" & vbNewLine & "Spreadsheets", "ENGR_SHEETS_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Link to the TAIT engineering spreadsheets.", "Open the TAIT engineering spreadsheets.", smallOmaticicon, largeOmaticicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Batch Change button definition.
            Dim largeBatchChangeicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.friendlyasm2_A3o_icon)
            Dim smallBatchChangeicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.friendlyasm2_A3o_icon)
            BtnBatchChange = controlDefs.AddButtonDefinition("Batch Dwg Change", "BATCH_CHANGE_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Controller for performing batch change procedures for all assembly components.", "Opens the Batch Change interface.", smallBatchChangeicon, largeBatchChangeicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Props Config button definition.
            Dim largePropsConfigicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.propconfig_c3T_icon)
            Dim smallPropsConfigicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.propconfig_c3T_icon)
            BtnPropConfig = controlDefs.AddButtonDefinition("Property" & vbNewLine & "Config", "PROP_CONFIG_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Opens a property modification form.", "Configure properties for populating drawing template.", smallPropsConfigicon, largePropsConfigicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the MK Dwg Ref Notes button definition.
            Dim largeMKdwgicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.mk_image_rlA_icon)
            Dim smallMKdwgicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.mushroom_super_icon_HJo_icon)
            BtnMKDwgRef = controlDefs.AddButtonDefinition("MK Dwg Ref", "MK_DWG_REF_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Opens reference for MK mechanical drawings.", "Open a reference doc for MK mechanical drawings.", smallMKdwgicon, largeMKdwgicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Apply MK Dwg Template button definition.
            Dim largeMKApplydwgtemplateicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.Ph03nyx_Super_Mario_Paper_Mario)
            Dim smallMKApplydwgtemplateicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.Ph03nyx_Super_Mario_Paper_Mario)
            BtnMKApplyDwgTemplate = controlDefs.AddButtonDefinition("MK Dwg Templates", "MK_DWG_TEMPLATE_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Updates MK Drawing templates for active drawing document.", "Updates MK Drawing templates for active drawing document.", smallMKApplydwgtemplateicon, largeMKApplydwgtemplateicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Apply MK Dwg Template button definition.
            Dim largeKAPPAApplydwgtemplateicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.cartoon_khaled_0m0_icon)
            Dim smallKAPPAApplydwgtemplateicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.cartoon_khaled_0m0_icon)
            BtnKAPPAApplyDwgTemplate = controlDefs.AddButtonDefinition("KAPPA Dwg Templates", "KAPPA_DWG_TEMPLATE_BUTTON", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Updates KAPPA Drawing templates for active drawing document.", "Updates KAPPA Drawing templates for active drawing document.", smallKAPPAApplydwgtemplateicon, largeKAPPAApplydwgtemplateicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the Standard Fastener Reference button definition.
            Dim largeStdFastenersicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources._3536___bolt_512_Ifz_icon)
            Dim smallStdFastenersicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources._3536___bolt_512_Ifz_icon)
            BtnStdFasteners = controlDefs.AddButtonDefinition("Standard Fasteners", "TAITPI_STD_FASTENERS", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Opens reference for TAIT PI Standard Fasteners.", "Open a reference for TAIT PI Standard Fasteners.", smallStdFastenersicon, largeStdFastenersicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Create the VaultConnStatus button definition.
            Dim largeVaultConnicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.connection_318_40172_K0B_icon)
            Dim smallVaultConnicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.connection_318_40172_K0B_icon)
            BtnTestVaultConn = controlDefs.AddButtonDefinition("Test Vault" & vbNewLine & "Connection", "VAULT_CONN", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Tests connection to Vault.", "Tests connection to Vault.", smallVaultConnicon, largeVaultConnicon, ButtonDisplayEnum.kAlwaysDisplayText)

            ctrlDefs = g_inventorApplication.TransientObjects.CreateObjectCollection()
            _ctrlDef1 = controlDefs.AddButtonDefinition("Button 1", "MenuDemo.Button1", CommandTypesEnum.kEditMaskCmdType, AddInClientID, "Button 1", "Button 1", PictureDispConverter.ToIPictureDisp(My.Resources.One_16x16), PictureDispConverter.ToIPictureDisp(My.Resources.One_32x32), ButtonDisplayEnum.kDisplayTextInLearningMode)
            _ctrlDef2 = controlDefs.AddButtonDefinition("Button 2", "MenuDemo.Button2", CommandTypesEnum.kEditMaskCmdType, AddInClientID, "Button 2", "Button 2", PictureDispConverter.ToIPictureDisp(My.Resources.Two_16x16), PictureDispConverter.ToIPictureDisp(My.Resources.Two_32x32), ButtonDisplayEnum.kDisplayTextInLearningMode)
            _ctrlDef3 = controlDefs.AddButtonDefinition("Button 3", "MenuDemo.Button3", CommandTypesEnum.kEditMaskCmdType, AddInClientID, "Button 3", "Button 3", PictureDispConverter.ToIPictureDisp(My.Resources.Three_16x16), PictureDispConverter.ToIPictureDisp(My.Resources.Three_32x32), ButtonDisplayEnum.kDisplayTextInLearningMode)
            ctrlDefs.Add(_ctrlDef1)
            ctrlDefs.Add(_ctrlDef2)
            ctrlDefs.Add(_ctrlDef3)

            'Create the DockableForm button definition.
            Dim largeDockFormicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.window_layout_positions_upper_left_512_U8w_icon)
            Dim smallDockFormicon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.window_layout_positions_upper_left_512_U8w_icon)
            BtnDockableForm = controlDefs.AddButtonDefinition("Open" & vbNewLine & "Dockable Form", "DOCK_FORM", CommandTypesEnum.kShapeEditCmdType, AddInClientID, "Opens a dockable form.", "Opens a dockable form.", smallDockFormicon, largeDockFormicon, ButtonDisplayEnum.kAlwaysDisplayText)

            'Add to the user interface, if it's the first time.
            If firstTime Then
                AddToUserInterface()
            End If
        End Sub

        ' This method is called by Inventor when the AddIn is unloaded. The AddIn will be
        ' unloaded either manually by the user or when the Inventor session is terminated.
        Public Sub Deactivate() Implements Inventor.ApplicationAddInServer.Deactivate

            ' Release objects.
            M_uiEvents = Nothing
            g_inventorApplication = Nothing
            BtnAddinInformation = Nothing
            BtnMaterialSpec = Nothing
            BtnGenerateDwgTree = Nothing
            BtnFindDrawings = Nothing
            BtnPrintDrawings = Nothing
            BtnModifyDwgNotes = Nothing
            BtnEngrSpreadsheets = Nothing
            BtnBatchChange = Nothing
            BtnPropConfig = Nothing
            BtnMKDwgRef = Nothing
            BtnMKApplyDwgTemplate = Nothing
            BtnKAPPAApplyDwgTemplate = Nothing
            BtnStdFasteners = Nothing
            BtnTestVaultConn = Nothing

            ctrlDefs = Nothing
            _ctrlDef1 = Nothing
            _ctrlDef2 = Nothing
            _ctrlDef3 = Nothing

            RemoveHandler BtnDockableForm.OnExecute, AddressOf BtnDockableForm_Clicked
            Marshal.ReleaseComObject(BtnDockableForm)
            BtnDockableForm = Nothing


            System.GC.Collect()
            System.GC.WaitForPendingFinalizers()
        End Sub

        ' This property is provided to allow the AddIn to expose an API of its own to other 
        ' programs. Typically, this  would be done by implementing the AddIn's API
        ' interface in a class and returning that class object through this property.
        Public ReadOnly Property Automation() As Object Implements Inventor.ApplicationAddInServer.Automation
            Get
                Return Nothing
            End Get
        End Property

        ' Note:this method is now obsolete, you should use the 
        ' ControlDefinition functionality for implementing commands.
        Public Sub ExecuteCommand(ByVal commandID As Integer) Implements Inventor.ApplicationAddInServer.ExecuteCommand
        End Sub

#End Region

#Region "User interface definition"
        ' Sub where the user-interface creation is done.  This is called when
        ' the add-in loaded and also if the user interface is reset.
        Private Sub AddToUserInterface()
            ' This is where code is added to add buttons to the ribbon.

            '' Create the various environment ribbons
            Dim zeroRibbon As Ribbon = g_inventorApplication.UserInterfaceManager.Ribbons.Item("ZeroDoc")
            Dim partRibbon As Ribbon = g_inventorApplication.UserInterfaceManager.Ribbons.Item("Part")
            Dim assemblyRibbon As Ribbon = g_inventorApplication.UserInterfaceManager.Ribbons.Item("Assembly")
            Dim drawingRibbon As Ribbon = g_inventorApplication.UserInterfaceManager.Ribbons.Item("Drawing")

            ''''''''ZERO DOC ENVIRONMENT''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Create the "TAIT PI" tab in the Zero Doc environment
            Dim TAITZeroDocTab As Inventor.RibbonTab = zeroRibbon.RibbonTabs.Add("TAIT PI", "TAIT_TAB", AddInClientID)

            ' Create a panel for Version Info.
            Dim InfozeroPanel As RibbonPanel = TAITZeroDocTab.RibbonPanels.Add("Add-in Version Info", "INFO_PANEL", AddInClientID)
            ' Add  buttons.
            InfozeroPanel.CommandControls.AddButton(BtnAddinInformation, True, True)

            ' Create a new panel for testing.
            Dim TESTpanel1 As RibbonPanel = TAITZeroDocTab.RibbonPanels.Add("Test Panel 1", "TEST_PANEL1", AddInClientID)
            ' Add buttons.
            TESTpanel1.CommandControls.AddButton(BtnTestVaultConn, True, True)
            TESTpanel1.CommandControls.AddButtonPopup(ctrlDefs, True, True)

            ' Create a new panel for testing.
            Dim TESTpanel2 As RibbonPanel = TAITZeroDocTab.RibbonPanels.Add("Test Panel 2", "TEST_PANEL2", AddInClientID)
            ' Add buttons.
            TESTpanel2.CommandControls.AddTogglePopup(_ctrlDef1, ctrlDefs, True, True)

            ' Create a new panel for testing.
            Dim TESTpanel3 As RibbonPanel = TAITZeroDocTab.RibbonPanels.Add("Test Panel 3", "TEST_PANEL3", AddInClientID)
            ' Add buttons.
            TESTpanel3.CommandControls.AddButton(BtnDockableForm, True, True)

            ''''''''PART ENVIRONMENT'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Create the "TAIT PI" tab in the Part environment
            Dim TAITPartTab As Inventor.RibbonTab = partRibbon.RibbonTabs.Add("TAIT PI", "TAIT_TAB", AddInClientID)

            ' Create a panel for Version Info.
            Dim InfopartPanel As RibbonPanel = TAITPartTab.RibbonPanels.Add("Add-in Version Info", "INFO_PANEL", AddInClientID)
            ' Add  buttons.
            InfopartPanel.CommandControls.AddButton(BtnAddinInformation, True, True)

            ' Create a new panel for materials and finishes.
            Dim MaterialsFinishesPanel As RibbonPanel = TAITPartTab.RibbonPanels.Add("Materials & Finishes", "M_F_PANEL", AddInClientID)
            ' Add buttons.
            MaterialsFinishesPanel.CommandControls.AddButton(BtnMaterialSpec, True, True)

            ' Create a panel for data processing tools.
            Dim ProcessingToolsPanel As RibbonPanel = TAITPartTab.RibbonPanels.Add("Data Processing Tools", "D_P_PANEL", AddInClientID)
            ' Add buttons.
            ProcessingToolsPanel.CommandControls.AddButton(BtnPropConfig, True, True)

            ' Create a new panel for design tools.
            Dim PartDesignToolsPanel As RibbonPanel = TAITPartTab.RibbonPanels.Add("Design Tools", "D_T_PANEL", AddInClientID)
            ' Add buttons.
            PartDesignToolsPanel.CommandControls.AddButton(BtnEngrSpreadsheets, True, True)

            ''''''''ASSEMBLY ENVIRONMENT''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Create the "TAIT PI" tab in the Assembly environment
            Dim TAITAsmTab As Inventor.RibbonTab = assemblyRibbon.RibbonTabs.Add("TAIT PI", "TAIT_TAB", AddInClientID)

            ' Create a panel for Version Info.
            Dim InfoasmPanel As RibbonPanel = TAITAsmTab.RibbonPanels.Add("Add-in Version Info", "INFO_PANEL", AddInClientID)
            ' Add buttons.
            InfoasmPanel.CommandControls.AddButton(BtnAddinInformation, True, True)

            ' Create a panel for Drawing tools.
            Dim AsmDrawingToolsPanel As RibbonPanel = TAITAsmTab.RibbonPanels.Add("Drawing Tools", "ASM_DWG_TOOLS_PANEL", AddInClientID)
            ' Add buttons.
            AsmDrawingToolsPanel.CommandControls.AddButton(BtnGenerateDwgTree, True, True)
            AsmDrawingToolsPanel.CommandControls.AddButton(BtnFindDrawings, True, True)
            AsmDrawingToolsPanel.CommandControls.AddButton(BtnPrintDrawings, True, True)

            ' Create a panel for design tools.
            Dim AsmDesignToolsPanel As RibbonPanel = TAITAsmTab.RibbonPanels.Add("Design Tools", "D_T_PANEL", AddInClientID)
            ' Add buttons.
            AsmDesignToolsPanel.CommandControls.AddButton(BtnEngrSpreadsheets, True, True)
            AsmDesignToolsPanel.CommandControls.AddButton(BtnStdFasteners, True, True)

            ' Create a panel for data processing tools.
            Dim AsmProcessingToolsPanel As RibbonPanel = TAITAsmTab.RibbonPanels.Add("Data Processing Tools", "D_P_PANEL", AddInClientID)
            ' Add buttons.
            AsmProcessingToolsPanel.CommandControls.AddButton(BtnBatchChange, True, True)
            AsmProcessingToolsPanel.CommandControls.AddButton(BtnPropConfig, True, True)

            ''''''''DRAWING ENVIRONMENT'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Create the "TAIT PI" tab in the Drawing environment
            Dim TAITDwgTab As Inventor.RibbonTab = drawingRibbon.RibbonTabs.Add("TAIT PI", "TAIT_TAB", AddInClientID)

            ' Create a panel for Version Info.
            Dim InfodwgPanel As RibbonPanel = TAITDwgTab.RibbonPanels.Add("Add-in Version Info", "INFO_PANEL", AddInClientID)
            ' Add buttons.
            InfodwgPanel.CommandControls.AddButton(BtnAddinInformation, True, True)

            ' Create a panel for Drawing tools.
            Dim DrawingToolsPanel As RibbonPanel = TAITDwgTab.RibbonPanels.Add("Drawing Tools", "DWG_TOOLS_PANEL", AddInClientID)
            ' Add buttons.
            DrawingToolsPanel.CommandControls.AddButton(BtnModifyDwgNotes, True, True)
            DrawingToolsPanel.CommandControls.AddButton(BtnMKApplyDwgTemplate, True, True)
            DrawingToolsPanel.CommandControls.AddButton(BtnKAPPAApplyDwgTemplate, True, True)

            'Create a panel for Drawing References
            Dim DrawingRefsPanel As RibbonPanel = TAITDwgTab.RibbonPanels.Add("Drawing References", "DWG_REFS_PANEL", AddInClientID)
            ' Add buttons.
            DrawingRefsPanel.CommandControls.AddButton(BtnMKDwgRef, False, True)
            DrawingRefsPanel.CommandControls.AddButton(BtnStdFasteners, True, True)

        End Sub

        Private Sub M_uiEvents_OnResetRibbonInterface(Context As NameValueMap) Handles M_uiEvents.OnResetRibbonInterface
            ' The ribbon was reset, so add back the add-ins user-interface.
            AddToUserInterface()
        End Sub
        Private Sub BtnMaterialSpec_OnExecute(Context As NameValueMap) Handles BtnMaterialSpec.OnExecute
            Dim MaterialSpecForm As New frmMaterialSpec 'Launch the frmMaterialSpec form when the button is clicked.
            MaterialSpecForm.ShowDialog()
        End Sub
        Private Sub BtnAddinInformation_OnExecute(Context As NameValueMap) Handles BtnAddinInformation.OnExecute
            Dim InfoForm As New frmVersionInfo 'Launch the frmVersionInfo form when the button is clicked.
            InfoForm.ShowDialog()
        End Sub
        Private Sub BtnGenerateDwgTree_OnExecute(Context As NameValueMap) Handles BtnGenerateDwgTree.OnExecute
            Dim oDoc As AssemblyDocument
            oDoc = g_inventorApplication.ActiveDocument
            ExportBOM(oDoc)
        End Sub
        Private Sub BtnFindDrawings_OnExecute(Context As NameValueMap) Handles BtnFindDrawings.OnExecute
            Dim oDoc As AssemblyDocument
            oDoc = g_inventorApplication.ActiveDocument

            Dim RUsure As Boolean
            RUsure = MessageBox.Show("This will create a TXT file for all of the assembly components that don't have drawings files." _
                & vbLf & "This rule expects that the drawing file shares the same name and location as the component." _
                & vbLf & " " _
                & vbLf & "Are you sure you want to create TXT for all of the assembly components?", "Drawing Check  - Batch Output .txt ", MessageBoxButtons.YesNo)
            If RUsure = vbNo Then
                Exit Sub
            End If

            Dim oContext As TranslationContext
            oContext = g_inventorApplication.TransientObjects.CreateTranslationContext
            oContext.Type = IOMechanismEnum.kFileBrowseIOMechanism

            Dim oOptions As NameValueMap                                                                            ' Create a NameValueMap object
            oOptions = g_inventorApplication.TransientObjects.CreateNameValueMap

            Dim oDataMedium As DataMedium                                                                           ' Create a DataMedium object
            oDataMedium = g_inventorApplication.TransientObjects.CreateDataMedium

            Dim oRefDocs As DocumentsEnumerator
            oRefDocs = oDoc.AllReferencedDocuments                                                               'look at the files referenced by the assembly
            Dim oRefDoc As Document

            Dim oReportFile As String
            Dim filename As String = g_inventorApplication.ActiveDocument.DisplayName
            oReportFile = filename & " - Drawing Status Report.txt"

            Dim oWrite As System.IO.StreamWriter = System.IO.File.CreateText(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & oReportFile)
            oWrite.WriteLine("Drawing Status Report")
            oWrite.WriteLine("___________________________________________________________" & vbNewLine)
            oWrite.WriteLine("Make sure to check the following parts for their drawings: " & vbNewLine)
            'work the drawing files for the referenced models
            'this expects that the model has a drawing of the same path and name 
            Dim partnumbersplit As String
            Dim stringarray() As String
            Dim n As Integer
            Dim partnumber As String
            Dim idwPathName As String
            Dim result As String

            For Each oRefDoc In oRefDocs
                idwPathName = Left(oRefDoc.FullDocumentName, Len(oRefDoc.FullDocumentName) - 3) & "dwg"
                'MsgBox(idwPathName)
                'check to see that the model has a drawing of the same path and name 
                If (System.IO.File.Exists(idwPathName)) = 0 Then                                                'check for drawing with same name in same location (Local VaultWIP location)

                    If oRefDoc.FullDocumentName.Contains("Design Accelerator") Then
                        GoTo SKIP
                    End If

                    partnumbersplit = oRefDoc.FullFileName
                    stringarray = partnumbersplit.Split("\")
                    n = -1
                    For Each txt In stringarray
                        n += 1
                    Next
                    partnumber = stringarray(n)
                    If Len(partnumber) < 11 Or partnumber Like "######[-]##[.]???" Or partnumber Like "######[-]##[-]##[.]???" Then
                        result = String.Format("{0,-40}{1,-40}", partnumber, oRefDoc.FullDocumentName)
                        oWrite.WriteLine(result)
                    End If
SKIP:
                End If
            Next

            oWrite.Close()

            Process.Start(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & oReportFile)

        End Sub
        Private Sub BtnPrintDrawings_OnExecute(Context As NameValueMap) Handles BtnPrintDrawings.OnExecute

            'get user okay
            If MessageBox.Show("This will create PDF, DWG and DXF files for all of the assembly component drawings." _
                & vbLf & "This rule expects that the drawing file shares the same name and location as the component in your local _VaultWIP folder." _
                & vbLf & " " _
                & vbLf & "Are you sure you want to create PDF and DWG Files for all of the assembly component drawings?", "Batch Print PDF, DWG, and DXF?", MessageBoxButtons.YesNo) = vbNo Then
                Exit Sub
            End If

            Dim VaultAddin As Inventor.ApplicationAddIn = g_inventorApplication.ApplicationAddIns.ItemById("{48B682BC-42E6-4953-84C5-3D253B52E77B}")
            VaultAddin.Deactivate()

            Dim oDoc As AssemblyDocument
            oDoc = g_inventorApplication.ActiveDocument
            Dim filename As String = oDoc.DisplayName.Substring(0, oDoc.DisplayName.Length - 4)

            'Set and then call PDF export engine variables
            Dim PDFAddIn As TranslatorAddIn
            Dim oContextPDF As TranslationContext
            Dim oOptionsPDF As NameValueMap
            Dim oDataMediumPDF As DataMedium
            Call ConfigurePDFAddinSettings(PDFAddIn, oContextPDF, oOptionsPDF, oDataMediumPDF)

            'Set and then call DWG export engine variables
            Dim DWGAddIn As TranslatorAddIn
            Dim oContextDWG As TranslationContext
            Dim oOptionsDWG As NameValueMap
            Dim oDataMediumDWG As DataMedium
            ConfigureDWGAddinSettings(DWGAddIn, oContextDWG, oOptionsDWG, oDataMediumDWG)

            Dim DesktopPath As String = My.Computer.FileSystem.SpecialDirectories.Desktop
            Dim oFolder As String = DesktopPath & "\" & filename & " - Drawing Files"

            If Not System.IO.Directory.Exists(oFolder) Then
                System.IO.Directory.CreateDirectory(oFolder)
            End If

            '- - - - - - - - - - - - -Component Drawings - - - - - - - - - - - -'look at the files referenced by the assembly
            Dim oRefDoc As Document
            Dim idwPathName As String
            Dim drawingname As String

            For Each oRefDoc In oDoc.AllReferencedDocuments
                idwPathName = Left(oRefDoc.FullDocumentName, Len(oRefDoc.FullDocumentName) - 3) & "dwg"
                drawingname = oRefDoc.DisplayName.Substring(0, oRefDoc.DisplayName.Length - 4)

                If (System.IO.File.Exists(idwPathName)) Then
                    Dim oDrawDoc As DrawingDocument
                    oDrawDoc = g_inventorApplication.Documents.Open(idwPathName, True)
                    Try
                        If oDrawDoc.Sheets.Count > 1 Then
                            For Each sht As Sheet In oDrawDoc.Sheets
                                sht.Activate()
                                g_inventorApplication.CommandManager.ControlDefinitions.Item("AppZoomallCmd").Execute()
                                sht.Update()
                                'Export PDF
                                If PDFAddIn.HasSaveCopyAsOptions(oDrawDoc, oContextPDF, oOptionsPDF) Then
                                    oDataMediumPDF.FileName = oFolder & "\" & drawingname & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & ".pdf"
                                    Call PDFAddIn.SaveCopyAs(oDrawDoc, oContextPDF, oOptionsPDF, oDataMediumPDF)
                                End If
                            Next
                            'Export DWG
                            If DWGAddIn.HasSaveCopyAsOptions(oDrawDoc, oContextDWG, oOptionsDWG) Then
                                oOptionsDWG.Value("Export_Acad_IniFile") = "C:\Users\Public\Documents\Autodesk\Inventor 2017\Design Data\DWG-DXF\exportdwg.ini"
                                oDataMediumDWG.FileName = oFolder & "\" & drawingname & ".dwg"
                                'oDataMediumDWG.FileName = oFolder & "\" & drawingname & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & ".dwg"
                                Call DWGAddIn.SaveCopyAs(oDrawDoc, oContextDWG, oOptionsDWG, oDataMediumDWG)
                            End If
                            'Export DXF
                            For Each sht As Sheet In oDrawDoc.Sheets
                                sht.Activate()
                                g_inventorApplication.CommandManager.ControlDefinitions.Item("AppZoomallCmd").Execute()
                                sht.Update()
                                Try
                                    Call oDrawDoc.SaveAs(oFolder & "\" & drawingname & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & ".dxf", True)
                                Catch ex As Exception
                                    MsgBox("Could not print " & drawingname & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & " to dxf")
                                End Try
                            Next
                        Else
                            g_inventorApplication.CommandManager.ControlDefinitions.Item("AppZoomallCmd").Execute()
                            'Export PDF
                            If PDFAddIn.HasSaveCopyAsOptions(oDrawDoc, oContextPDF, oOptionsPDF) Then
                                oDataMediumPDF.FileName = oFolder & "\" & drawingname & ".pdf"
                                Call PDFAddIn.SaveCopyAs(oDrawDoc, oContextPDF, oOptionsPDF, oDataMediumPDF)
                            End If
                            'Export DWG
                            If DWGAddIn.HasSaveCopyAsOptions(oDrawDoc, oContextDWG, oOptionsDWG) Then
                                oOptionsDWG.Value("Export_Acad_IniFile") = "C:\Users\Public\Documents\Autodesk\Inventor 2017\Design Data\DWG-DXF\exportdwg.ini"
                                oDataMediumDWG.FileName = oFolder & "\" & drawingname & ".dwg"
                                Call DWGAddIn.SaveCopyAs(oDrawDoc, oContextDWG, oOptionsDWG, oDataMediumDWG)
                            End If
                            'Export DXF
                            Try
                                Call oDrawDoc.SaveAs(oFolder & "\" & drawingname & ".dxf", True)
                            Catch ex As Exception
                                MsgBox("Could not print " & drawingname & " to dxf")
                            End Try
                        End If

                    Catch ex As Exception
                        'MsgBox("Error printing " & drawingname)
                    End Try
                    oDrawDoc.Close(True)
                Else
                    'MsgBox("Error finding drawing for" & drawingname)
                End If
            Next
            '- - - - - - - - - - - - -
            '- - - - - - - - - - - - -Top Level Drawing - - - - - - - - - - - -
            Dim oAsmDrawingName As String
            Dim asmdrawingPathName As String = g_inventorApplication.ActiveDocument.FullFileName.Substring(0, g_inventorApplication.ActiveDocument.FullFileName.Length - 3) & "dwg"

            If (System.IO.File.Exists(asmdrawingPathName)) Then
                Dim oAsmDrawingDoc As DrawingDocument
                oAsmDrawingDoc = g_inventorApplication.Documents.Open(g_inventorApplication.ActiveDocument.FullFileName.Substring(0, g_inventorApplication.ActiveDocument.FullFileName.Length - 3) & "dwg", True)
                oAsmDrawingName = oAsmDrawingDoc.DisplayName.Substring(0, oAsmDrawingDoc.DisplayName.Length - 4)

                Try
                    If oAsmDrawingDoc.Sheets.Count > 1 Then
                        For Each sht As Sheet In oAsmDrawingDoc.Sheets
                            sht.Activate()
                            g_inventorApplication.CommandManager.ControlDefinitions.Item("AppZoomallCmd").Execute()
                            sht.Update()
                            'Export PDF
                            'Old method = Call oAsmDrawingDoc.SaveAs(oFolder & "\" & oAsmDrawingName & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & ".pdf", True)
                            If PDFAddIn.HasSaveCopyAsOptions(oAsmDrawingDoc, oContextPDF, oOptionsPDF) Then
                                oDataMediumPDF.FileName = oFolder & "\" & oAsmDrawingName & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & ".pdf"
                                PDFAddIn.SaveCopyAs(oAsmDrawingDoc, oContextPDF, oOptionsPDF, oDataMediumPDF)
                            End If
                        Next
                        'Export DWG
                        If DWGAddIn.HasSaveCopyAsOptions(oAsmDrawingDoc, oContextDWG, oOptionsDWG) Then
                            oOptionsDWG.Value("Export_Acad_IniFile") = "C:\Users\Public\Documents\Autodesk\Inventor 2017\Design Data\DWG-DXF\exportdwg.ini"
                            'oDataMediumDWG.FileName = oFolder & "\" & oAsmDrawingName & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & ".dwg"
                            oDataMediumDWG.FileName = oFolder & "\" & oAsmDrawingName & ".dwg"
                            Call DWGAddIn.SaveCopyAs(oAsmDrawingDoc, oContextDWG, oOptionsDWG, oDataMediumDWG)
                        End If
                        'Export DXF
                        For Each sht As Sheet In oAsmDrawingDoc.Sheets
                            sht.Activate()
                            g_inventorApplication.CommandManager.ControlDefinitions.Item("AppZoomallCmd").Execute()
                            sht.Update()
                            Try
                                Call oAsmDrawingDoc.SaveAs(oFolder & "\" & oAsmDrawingName & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & ".dxf", True)
                            Catch ex As Exception
                                MsgBox("Could not print " & oAsmDrawingName & "_Sheet " & sht._DisplayName.Substring(sht._DisplayName.Length - 1, 1) & " to dxf")
                            End Try
                        Next

                    Else
                        g_inventorApplication.CommandManager.ControlDefinitions.Item("AppZoomallCmd").Execute()
                        'Export PDF
                        'Old Method = Call oAsmDrawingDoc.SaveAs(oFolder & "\" & oAsmDrawingName & ".pdf", True)
                        If PDFAddIn.HasSaveCopyAsOptions(oAsmDrawingDoc, oContextPDF, oOptionsPDF) Then
                            oDataMediumPDF.FileName = oFolder & "\" & oAsmDrawingName & ".pdf"
                            PDFAddIn.SaveCopyAs(oAsmDrawingDoc, oContextPDF, oOptionsPDF, oDataMediumPDF)

                        End If
                        'Export DWG
                        If DWGAddIn.HasSaveCopyAsOptions(oAsmDrawingDoc, oContextDWG, oOptionsDWG) Then
                            oOptionsDWG.Value("Export_Acad_IniFile") = "C:\Users\Public\Documents\Autodesk\Inventor 2017\Design Data\DWG-DXF\exportdwg.ini"
                            oDataMediumDWG.FileName = oFolder & "\" & oAsmDrawingName & ".dwg"
                            Call DWGAddIn.SaveCopyAs(oAsmDrawingDoc, oContextDWG, oOptionsDWG, oDataMediumDWG)
                        End If
                        'Export DXF
                        Try
                            Call oAsmDrawingDoc.SaveAs(oFolder & "\" & oAsmDrawingName & ".dxf", True)
                        Catch ex As Exception
                            MsgBox("Could not print " & oAsmDrawingName & " to dxf")
                        End Try

                    End If

                Catch ex As Exception
                    'MsgBox("Error printing " & oAsmDrawingName)
                End Try
                oAsmDrawingDoc.Close(True)
            Else
                'MsgBox("Error finding drawing for" & filename)
            End If

            MsgBox("New drawing files created in: " & vbNewLine & filename & " - Drawing Files")
            Process.Start(oFolder)
            VaultAddin.Activate()

        End Sub
        Sub ConfigurePDFAddinSettings(ByRef PDFAddIn As TranslatorAddIn, ByRef oContextPDF As TranslationContext, ByRef oOptionsPDF As NameValueMap, ByRef oDataMediumPDF As DataMedium)

            PDFAddIn = g_inventorApplication.ApplicationAddIns.ItemById("{0AC6FD96-2F4D-42CE-8BE0-8AEA580399E4}")
            oContextPDF = g_inventorApplication.TransientObjects.CreateTranslationContext
            oContextPDF.Type = IOMechanismEnum.kFileBrowseIOMechanism

            oOptionsPDF = g_inventorApplication.TransientObjects.CreateNameValueMap
            oOptionsPDF.Value("All_Color_AS_Black") = 0
            oOptionsPDF.Value("Remove_Line_Weights") = 0
            oOptionsPDF.Value("Vector_Resolution") = 2400
            oOptionsPDF.Value("Sheet_Range") = PrintRangeEnum.kPrintCurrentSheet
            'oOptionsPDF.Value("Custom_Begin_Sheet") = 1
            'oOptionsPDF.Value("Custom_End_Sheet") = 1

            oDataMediumPDF = g_inventorApplication.TransientObjects.CreateDataMedium
        End Sub
        Sub ConfigureDWGAddinSettings(ByRef DWGAddIn As TranslatorAddIn, ByRef oContextDWG As TranslationContext, ByRef oOptionsDWG As NameValueMap, ByRef oDataMediumDWG As DataMedium)

            DWGAddIn = g_inventorApplication.ApplicationAddIns.ItemById("{C24E3AC2-122E-11D5-8E91-0010B541CD80}")
            oContextDWG = g_inventorApplication.TransientObjects.CreateTranslationContext
            oContextDWG.Type = IOMechanismEnum.kFileBrowseIOMechanism

            oOptionsDWG = g_inventorApplication.TransientObjects.CreateNameValueMap

            oDataMediumDWG = g_inventorApplication.TransientObjects.CreateDataMedium
        End Sub
        Private Sub BtnModifyDwgNotes_OnExecute(Context As NameValueMap) Handles BtnModifyDwgNotes.OnExecute
            Dim ModifyNotesForm As New frmModifyDwgNotes 'Launch the frmModifyDwgNotes form when the button is clicked.
            ModifyNotesForm.ShowDialog()
        End Sub
        Private Sub BtnEngrSpreadsheets_OnExecute(Context As NameValueMap) Handles BtnEngrSpreadsheets.OnExecute
            Dim DIRECTORY_NAME As String = "S:\REFERENCE\ENGINEERING\Spreadsheets"

            If System.IO.Directory.Exists(DIRECTORY_NAME) = True Then
                Process.Start(DIRECTORY_NAME)
            Else
                MsgBox("Could not find specified directory.")
            End If
        End Sub
        Public excelApp As Microsoft.Office.Interop.Excel.Application
        Public wb As Microsoft.Office.Interop.Excel.Workbook
        Public xlws1 As Worksheet
        Public xlws2 As Worksheet
        Sub ExportBOM(oDoc As Document)

            Dim drawingtreeSS1 As New frmDrawingTreeSplashScreen
            drawingtreeSS1.Label1.Text = "Processing BOM Export..."
            drawingtreeSS1.ShowDialog()

            Dim sFileName As String
            sFileName = oDoc.FullFileName
            'Dim oMasterLODDoc As AssemblyDocument
            'oMasterLODDoc = g_inventorApplication.Documents.Open(sFileName, False)
            Dim oBOM As Inventor.BOM
            oBOM = oDoc.ComponentDefinition.BOM
            oBOM.ImportBOMCustomization("Z:\GDH\Programs\Inventor iLogic and other files\PartsTreeFormat.xml")
            'oBOM.PartsOnlyViewEnabled = True
            oBOM.StructuredViewEnabled = True
            oBOM.StructuredViewFirstLevelOnly = False
            oBOM.StructuredViewDelimiter = "-"
            Dim oBOMView As BOMView
            oBOMView = oBOM.BOMViews.Item("Structured")
            Dim Time As DateTime = DateTime.Now
            Dim Format As String = "yyyy.M.d"
            Dim fname As String = g_inventorApplication.ActiveDocument.DisplayName
            Dim docname As String = fname.Substring(0, fname.Length - 4)
            oBOMView.Export(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Time.ToString(Format) & "_" & fname & "_PartsTree.xlsm", FileFormatEnum.kMicrosoftExcelFormat)

            drawingtreeSS1.Hide()
            MsgBox(Time.ToString(Format) & "_" & g_inventorApplication.ActiveDocument.DisplayName & "_PartsTree.xlsm exported successfully!" & vbNewLine & "File can be found on the Desktop." & vbNewLine & "Attampting to open file and generate drawing tree...",, "Successful BOM Export!")
            drawingtreeSS1.Label1.Text = "Configuring drawing tree..."
            drawingtreeSS1.Show()

            'Excel processing
            excelApp = CreateObject("Excel.Application")
            excelApp.Visible = False
            excelApp.DisplayAlerts = False

            wb = excelApp.Workbooks.Open(My.Computer.FileSystem.SpecialDirectories.Desktop & "\" & Time.ToString(Format) & "_" & fname & "_PartsTree.xlsm")
            xlws1 = wb.Worksheets(1)

            Call ReorderXLBOM()
            excelApp.Columns.AutoFit()

            drawingtreeSS1.Hide()
            'Dim docdescription As String = g_inventorApplication.ActiveDocument.PropertySets.Item("Inventor User Defined Properties").Item("Description").Value
            'Call CreatePartsTree(docname, docdescription)
            Call CreatePartsTree()

            excelApp = Nothing

        End Sub
        Sub ReorderXLBOM()
            Dim ndx As Integer
            Dim Found As Range
            Dim counter As Integer = 1

            Dim arrColOrder() As String = {"Item", "Part Number", "Thumbnail", "BOM Structure", "Unit QTY", "QTY", "Stock Number", "Description", "REV", "MakeBuy", "UsedOn", "NextAssy", "Material"}

            On Error Resume Next

            For ndx = LBound(arrColOrder) To UBound(arrColOrder)

                'Set Found = xlws.Rows("1:1").Find(arrColOrder(ndx),, LookIn:=xlValues, LookAt:=xlWhole, SearchOrder:=xlByColumns, SearchDirection:=xlNext, MatchCase:=False)
                Found = xlws1.Rows("1:1").Find(arrColOrder(ndx), , -4163, 1, 2, 1, False)

                If Err.Number <> 0 Then
                    MsgBox("Error With Excel FIND function: " & Err.Number & " :: " & Err.Description & vbLf & vbLf & ndx)
                    Err.Clear()
                End If

                If Not Found Is Nothing Then
                    If Found.Column <> counter Then
                        Found.EntireColumn.Cut()
                        xlws1.Columns(counter).Insert(-4161)
                        excelApp.CutCopyMode = False
                    End If
                    counter = counter + 1
                End If
            Next

            If Err.Number <> 0 Then
                MsgBox("Reorder Columns Rule Error: " & Err.Number & " :: " & Err.Description & vbLf & vbLf & ndx)
                Err.Clear()
            End If
        End Sub
        Sub CreatePartsTree()
            Dim oSALayout As SmartArtLayout
            Dim QNode As SmartArtNode
            Dim LastNode As SmartArtNode
            Dim QNodes As SmartArtNodes
            Dim GlobalParNode As SmartArtNode
            Dim ParNode As SmartArtNode
            Dim S1 As String
            Dim S2 As String
            Dim RootCount As Integer
            Dim LevelCount As Integer
            Dim x As Integer
            Dim LString As String
            Dim LArray() As String
            Dim first As Integer
            Dim last As Integer
            Dim lengthOfArray As Integer
            Dim inputINFOpartnumber As Object
            Dim inputINFOtitle As Object
            Dim oShp As Microsoft.Office.Interop.Excel.Shape

            inputINFOpartnumber = InputBox("Please input the Element Part Number")
            'inputINFOpartnumber = nme
            inputINFOtitle = InputBox("Please input the Element Title")
            'inputINFOtitle = dcrptn

            Dim drawingtreeSS2 As New frmDrawingTreeSplashScreen
            drawingtreeSS2.Label1.Text = "Configuring drawing tree..."
            drawingtreeSS2.ShowDialog()

            oSALayout = excelApp.SmartArtLayouts(97)                                    'reference to block organization chart
            oShp = wb.ActiveSheet.Shapes.AddSmartArt(oSALayout)

            QNodes = oShp.SmartArt.AllNodes                                             'select all original nodes
            For i = 1 To 5                                                              'delete all original nodes
                oShp.SmartArt.AllNodes(1).Delete()
            Next

            GlobalParNode = oShp.SmartArt.AllNodes.Add
            S1 = inputINFOpartnumber
            S2 = inputINFOtitle
            GlobalParNode.TextFrame2.TextRange.Text = S1 & vbNewLine & S2

            Dim targetcell As Range
            targetcell = wb.Worksheets(1).Range("A2")
            Dim NumRows As Integer
            NumRows = wb.ActiveSheet.Range("A2", wb.ActiveSheet.Range("A2").end(XlDirection.xlDown)).Rows.Count                   ' Set numrows = number of rows of data.

            LevelCount = 0
            RootCount = 0

            For x = 1 To NumRows                                                        ' Establish "For" loop to loop "numrows" number of times.
                If CStr(targetcell.Value) Like "#" Or CStr(targetcell.Value) Like "##" Then
                    If targetcell.Offset(0, 9).Value = "Buy" Or targetcell.Offset(0, 9).Value = "" Then
                        GoTo NXT
                    End If

                    QNode = GlobalParNode.AddNode(MsoSmartArtNodePosition.msoSmartArtNodeBelow)
                    S1 = targetcell.Offset(0, 1).Value
                    S2 = targetcell.Offset(0, 7).Value
                    QNode.TextFrame2.TextRange.Text = S1 & vbNewLine & S2

                    RootCount = RootCount + 1

                    ParNode = QNode

                Else
                    If targetcell.Offset(0, 9).Value = "Buy" Or targetcell.Offset(0, 9).Value = "" Then
                        GoTo NXT
                    End If

                    LString = CStr(targetcell.Value)
                    LArray = Split(LString, "-")
                    first = LBound(LArray)
                    last = UBound(LArray)
                    lengthOfArray = last - first
                    If lengthOfArray > LevelCount Then
                        LevelCount = lengthOfArray
                    End If

                    Call GetChild(targetcell, lengthOfArray, ParNode, LastNode)

                End If

NXT:
                targetcell = targetcell.Offset(1, 0) ' Selects cell down 1 row from active cell.
            Next

            'MsgBox ("RootCount: " & RootCount & vbNewLine & "LevelCount: " & LevelCount)

            oShp.SmartArt.Color = excelApp.SmartArtColors(1)

            drawingtreeSS2.Hide()
            excelApp.Visible = True
            excelApp.ScreenUpdating = True

        End Sub
        Sub GetChild(targetcell As Range, lengthOfArray As Integer, ParNode As SmartArtNode, LastNode As SmartArtNode)
            Dim LString As String
            Dim LArray() As String
            Dim first As Integer
            Dim last As Integer
            Dim lengthOfArrayNext As Integer
            Dim Qnode As SmartArtNode

            Qnode = ParNode.AddNode(MsoSmartArtNodePosition.msoSmartArtNodeBelow)

            Dim S1 As String
            Dim S2 As String
            'Dim S1 As Microsoft.Office.Interop.Excel.Range
            'Dim S2 As Microsoft.Office.Interop.Excel.Range
            S1 = targetcell.Offset(0, 1).Value
            S2 = targetcell.Offset(0, 7).Value
            Qnode.TextFrame2.TextRange.Text = S1 & vbNewLine & S2

            LString = CStr(targetcell.Offset(1, 0).Value)
            LArray = Split(LString, "-")
            first = LBound(LArray)
            last = UBound(LArray)
            lengthOfArrayNext = last - first
            'MsgBox ("Level: " & lengthOfArray & vbNewLine & "Next Level: " & lengthOfArrayNext)
            If lengthOfArrayNext > lengthOfArray Then           'keep going down
                LastNode = ParNode
                ParNode = QNode
            ElseIf lengthOfArrayNext < lengthOfArray Then       'go back up a level
                ParNode = LastNode
            End If

        End Sub
        Private Sub BtnBatchChange_OnExecute(Context As NameValueMap) Handles BtnBatchChange.OnExecute
            Dim BatchChangeform As New frmBatchChange 'Launch the frmSmartPartPRO form when the button is clicked.
            BatchChangeform.ShowDialog()
        End Sub
        Public Sub BtnPropConfig_OnExecute(Context As NameValueMap) Handles BtnPropConfig.OnExecute
            Dim PropertyConfigForm As New frmPropConfig 'Launch the frmSmartPartPRO form when the button is clicked.
            PropertyConfigForm.ShowDialog()
        End Sub
        Private Sub BtnMKDwgRef_OnExecute(Context As NameValueMap) Handles BtnMKDwgRef.OnExecute
            Dim FileDestinationName As String = "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\PI_Drawing References\Mario Kart Sample Kit Drawing 2018.04.06.pdf"

            If System.IO.File.Exists(FileDestinationName) = True Then
                Process.Start(FileDestinationName)
            Else
                MsgBox("Could not find specified file.")
            End If
        End Sub
        Private Sub BtnStdFasteners_OnExecute(Context As NameValueMap) Handles BtnStdFasteners.OnExecute
            Dim FileDestinationName As String = "Z:\PERMANENT INSTALL\Programming\TAIT PI Inventor Add-in\PI_Standard Documents\TAIT PI Standard Hardware 2018.04.30.pdf"

            If System.IO.File.Exists(FileDestinationName) = True Then
                Process.Start(FileDestinationName)
            Else
                MsgBox("Could not find specified file.")
            End If
        End Sub
        Private Sub BtnMKApplyDwgTemplate_OnExecute(Context As NameValueMap) Handles BtnMKApplyDwgTemplate.OnExecute

            Dim result As Integer = MessageBox.Show("Would you like to update MK drawing templates in the active drawing document?", "Continue template update?", MessageBoxButtons.OKCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            End If
            'Dim myConnection As VDF.Vault.Currency.Connections.Connection = Nothing
            '' Get the Vault connection from 
            '' the Inventor Vault log in
            'myConnection = Connectivity.VaultBase.ConnectionManager.Instance.Connection()

            ' Connect to a running instance of Inventor. 
            Dim invApp As Inventor.Application
            invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

            Dim oNVM As NameValueMap
            oNVM = invApp.TransientObjects.CreateNameValueMap

            ' Get the active document. 
            Dim Doc As Inventor.DrawingDocument
            Doc = invApp.ActiveDocument

            Dim oTemplate As DrawingDocument
            Dim oSourceCoverSheetBlockDef As TitleBlockDefinition
            Dim oSourceMainSheetBlockDef As TitleBlockDefinition
            Dim oNewCoverSheetBlockDef As TitleBlockDefinition
            Dim oNewMainSheetBlockDef As TitleBlockDefinition
            Dim oSheet As Sheet

            Dim Fname As String = "Mario Kart dwg template.dwg"
            Dim CoverSheetName As String = "UNIVERSAL MARIO KART COVER SHEET"
            Dim MainSheetName As String = "UNIVERSAL MARIO KART"
            oTemplate = invApp.Documents.OpenWithOptions("C:\_vaultWIP\Designs\Templates\Universal\" & Fname, oNVM, False)
            oSourceCoverSheetBlockDef = oTemplate.TitleBlockDefinitions.Item(CoverSheetName)
            oSourceMainSheetBlockDef = oTemplate.TitleBlockDefinitions.Item(MainSheetName)

            'oNewTitleBlockDef = oSourceTitleBlockDef.CopyTo(oDrawDoc, True)
            ' Iterate through the sheets.
            For Each oSheet In Doc.Sheets
                oSheet.Activate() 'Activate sheet
                If oSheet.TitleBlock.Definition.Name = CoverSheetName Then
                    'MsgBox("Hit cover sheet change.")
                    Try
                        oNewCoverSheetBlockDef = oSourceCoverSheetBlockDef.CopyTo(Doc, True)
                        oSheet.TitleBlock.Delete()
                        oSheet.AddTitleBlock(oNewCoverSheetBlockDef)
                    Catch ex As Exception
                        MsgBox("Error inserting Cover Sheet title block.")
                    End Try

                ElseIf oSheet.TitleBlock.Definition.Name = MainSheetName Then
                    'MsgBox("Hit main sheet change.")
                    Try
                        oNewMainSheetBlockDef = oSourceMainSheetBlockDef.CopyTo(Doc, True)
                        oSheet.TitleBlock.Delete()
                        oSheet.AddTitleBlock(oNewMainSheetBlockDef)
                    Catch ex As Exception
                        MsgBox("Error inserting Main Sheet title block.")
                    End Try
                Else
                    MsgBox("Could not update title blocks.")
                End If
            Next
            oTemplate.Close(True)

            invApp = Nothing
            Doc = Nothing
        End Sub

        Private Sub BtnKAPPAApplyDwgTemplate_OnExecute(Context As NameValueMap) Handles BtnKAPPAApplyDwgTemplate.OnExecute

            Dim result As Integer = MessageBox.Show("Would you like to update KAPPA drawing templates in the active drawing document?", "Continue template update?", MessageBoxButtons.OKCancel)
            If result = DialogResult.Cancel Then
                Exit Sub
            End If
            'Dim myConnection As VDF.Vault.Currency.Connections.Connection = Nothing
            '' Get the Vault connection from 
            '' the Inventor Vault log in
            'myConnection = Connectivity.VaultBase.ConnectionManager.Instance.Connection()

            ' Connect to a running instance of Inventor. 
            Dim invApp As Inventor.Application
            invApp = System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application")

            Dim oNVM As NameValueMap
            oNVM = invApp.TransientObjects.CreateNameValueMap

            ' Get the active document. 
            Dim Doc As Inventor.DrawingDocument
            Doc = invApp.ActiveDocument

            Dim oTemplate As DrawingDocument
            Dim oSourceCoverSheetBlockDef As TitleBlockDefinition
            Dim oSourceMainSheetBlockDef As TitleBlockDefinition
            Dim oNewCoverSheetBlockDef As TitleBlockDefinition
            Dim oNewMainSheetBlockDef As TitleBlockDefinition
            Dim oSheet As Sheet

            Dim Fname As String = "Project KAPPA dwg template.dwg"
            Dim CoverSheetName As String = "PROJECT KAPPA COVER SHEET"
            Dim MainSheetName As String = "PROJECT KAPPA"
            oTemplate = invApp.Documents.OpenWithOptions("C:\_vaultWIP\Designs\Templates\Disney\" & Fname, oNVM, False)
            oSourceCoverSheetBlockDef = oTemplate.TitleBlockDefinitions.Item(CoverSheetName)
            oSourceMainSheetBlockDef = oTemplate.TitleBlockDefinitions.Item(MainSheetName)

            'oNewTitleBlockDef = oSourceTitleBlockDef.CopyTo(oDrawDoc, True)
            ' Iterate through the sheets.
            For Each oSheet In Doc.Sheets
                oSheet.Activate() 'Activate sheet
                If oSheet.TitleBlock.Definition.Name = CoverSheetName Then
                    'MsgBox("Hit cover sheet change.")
                    Try
                        oNewCoverSheetBlockDef = oSourceCoverSheetBlockDef.CopyTo(Doc, True)
                        oSheet.TitleBlock.Delete()
                        oSheet.AddTitleBlock(oNewCoverSheetBlockDef)
                    Catch ex As Exception
                        MsgBox("Error inserting Cover Sheet title block.")
                    End Try

                ElseIf oSheet.TitleBlock.Definition.Name = MainSheetName Then
                    'MsgBox("Hit main sheet change.")
                    Try
                        oNewMainSheetBlockDef = oSourceMainSheetBlockDef.CopyTo(Doc, True)
                        oSheet.TitleBlock.Delete()
                        oSheet.AddTitleBlock(oNewMainSheetBlockDef)
                    Catch ex As Exception
                        MsgBox("Error inserting Main Sheet title block.")
                    End Try
                Else
                    MsgBox("Could not update title blocks.")
                End If
            Next
            oTemplate.Close(True)

            invApp = Nothing
            Doc = Nothing
        End Sub

        Private Sub BtnTestVaultConn_OnExecute(Context As NameValueMap) Handles BtnTestVaultConn.OnExecute
            Dim strVaulrServerName As String = Connectivity.InventorAddin.EdmAddin.EdmSecurity.Instance.GetEdmLoginPreferences.Server
            Dim strVaultName As String = Connectivity.InventorAddin.EdmAddin.EdmSecurity.Instance.GetEdmLoginPreferences.VaultName
            Dim strVaultUserName As String = Connectivity.InventorAddin.EdmAddin.EdmSecurity.Instance.GetEdmLoginPreferences.UserName
            Dim strVaultPassword As String = Connectivity.InventorAddin.EdmAddin.EdmSecurity.Instance.GetEdmLoginPreferences.Password

            MsgBox("Server: " & strVaulrServerName & vbNewLine &
                   "Name: " & strVaultName & vbNewLine &
                   "Username: " & strVaultUserName & vbNewLine &
                   "Password: " & strVaultPassword)

            Dim results As VDF.Vault.Results.LogInResult
            results = VDF.Vault.Library.ConnectionManager.LogIn(strVaulrServerName, strVaultName, strVaultUserName, strVaultPassword, VDF.Vault.Currency.Connections.AuthenticationFlags.WindowsAuthentication, Nothing)

            Dim conn As VDF.Vault.Currency.Connections.Connection = Nothing

            If results.Success Then
                conn = results.Connection
                MsgBox("Connected to Vault!")
            Else
                MsgBox("Failed to find connection to Vault.")
            End If
        End Sub
        Private Sub Button1_Clicked(ByVal context As NameValueMap) Handles _ctrlDef1.OnExecute
            MsgBox("Button 1 was clicked.")
        End Sub
        Private Sub Button2_Clicked(ByVal context As NameValueMap) Handles _ctrlDef2.OnExecute
            MsgBox("Button 2 was clicked.")
        End Sub
        Private Sub Button3_Clicked(ByVal context As NameValueMap) Handles _ctrlDef3.OnExecute
            MsgBox("Button 3 was clicked.")
        End Sub
        Private Sub BtnDockableForm_Clicked(ByVal context As NameValueMap) Handles BtnDockableForm.OnExecute
            MsgBox("Opening Dockable form...")
            Dim f As DockForm = New DockForm(g_inventorApplication, AddInClientID)
            'f.Visible = False
            f.ShowDialog()
        End Sub

#End Region

    End Class
End Namespace


Public Module Globals
    ' Inventor application object.
    Public g_inventorApplication As Inventor.Application

#Region "Function to get the add-in client ID."
    ' This function uses reflection to get the GuidAttribute associated with the add-in.
    Public Function AddInClientID() As String
        Dim guid As String = ""
        Try
            Dim t As Type = GetType(TAITInventorAddIn.StandardAddInServer)
            Dim customAttributes() As Object = t.GetCustomAttributes(GetType(GuidAttribute), False)
            Dim guidAttribute As GuidAttribute = CType(customAttributes(0), GuidAttribute)
            guid = "{" + guidAttribute.Value.ToString() + "}"
        Catch
        End Try

        Return guid
    End Function
#End Region

#Region "hWnd Wrapper Class"
    ' This class is used to wrap a Win32 hWnd as a .Net IWind32Window class.
    ' This is primarily used for parenting a dialog to the Inventor window.
    '
    ' For example:
    ' myForm.Show(New WindowWrapper(g_inventorApplication.MainFrameHWND))
    '
    Public Class WindowWrapper
        Implements System.Windows.Forms.IWin32Window
        Public Sub New(ByVal handle As IntPtr)
            _hwnd = handle
        End Sub

        Public ReadOnly Property Handle() As IntPtr _
          Implements System.Windows.Forms.IWin32Window.Handle
            Get
                Return _hwnd
            End Get
        End Property

        Private _hwnd As IntPtr
    End Class
#End Region

#Region "Image Converter"
    ' Class used to convert bitmaps and icons from their .Net native types into
    ' an IPictureDisp object which is what the Inventor API requires. A typical
    ' usage is shown below where MyIcon is a bitmap or icon that's available
    ' as a resource of the project.
    '
    ' Dim smallIcon As stdole.IPictureDisp = PictureDispConverter.ToIPictureDisp(My.Resources.MyIcon)

    Public NotInheritable Class PictureDispConverter
        <DllImport("OleAut32.dll", EntryPoint:="OleCreatePictureIndirect", ExactSpelling:=True, PreserveSig:=False)> _
        Private Shared Function OleCreatePictureIndirect( _
            <MarshalAs(UnmanagedType.AsAny)> ByVal picdesc As Object, _
            ByRef iid As Guid, _
            <MarshalAs(UnmanagedType.Bool)> ByVal fOwn As Boolean) As stdole.IPictureDisp
        End Function

        Shared iPictureDispGuid As Guid = GetType(stdole.IPictureDisp).GUID

        Private NotInheritable Class PICTDESC
            Private Sub New()
            End Sub

            'Picture Types
            Public Const PICTYPE_BITMAP As Short = 1
            Public Const PICTYPE_ICON As Short = 3

            <StructLayout(LayoutKind.Sequential)> _
            Public Class Icon
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Icon))
                Friend picType As Integer = PICTDESC.PICTYPE_ICON
                Friend hicon As IntPtr = IntPtr.Zero
                Friend unused1 As Integer
                Friend unused2 As Integer

                Friend Sub New(ByVal icon As System.Drawing.Icon)
                    Me.hicon = icon.ToBitmap().GetHicon()
                End Sub
            End Class

            <StructLayout(LayoutKind.Sequential)> _
            Public Class Bitmap
                Friend cbSizeOfStruct As Integer = Marshal.SizeOf(GetType(PICTDESC.Bitmap))
                Friend picType As Integer = PICTDESC.PICTYPE_BITMAP
                Friend hbitmap As IntPtr = IntPtr.Zero
                Friend hpal As IntPtr = IntPtr.Zero
                Friend unused As Integer

                Friend Sub New(ByVal bitmap As System.Drawing.Bitmap)
                    Me.hbitmap = bitmap.GetHbitmap()
                End Sub
            End Class
        End Class

        Public Shared Function ToIPictureDisp(ByVal icon As System.Drawing.Icon) As stdole.IPictureDisp
            Dim pictIcon As New PICTDESC.Icon(icon)
            Return OleCreatePictureIndirect(pictIcon, iPictureDispGuid, True)
        End Function

        Public Shared Function ToIPictureDisp(ByVal bmp As System.Drawing.Bitmap) As stdole.IPictureDisp
            Dim pictBmp As New PICTDESC.Bitmap(bmp)
            Return OleCreatePictureIndirect(pictBmp, iPictureDispGuid, True)
        End Function
    End Class
#End Region

End Module

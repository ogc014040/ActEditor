using System;
using System.Collections.Generic;

namespace ActEditor.ApplicationConfiguration {
	/// <summary>
	/// Manages localization strings for ActEditor.
	/// Supports English (en-US) and Traditional Chinese (zh-TW).
	/// </summary>
	public static class LocalizationManager {
		private static Dictionary<string, string> _strings;
		private static string _currentLanguage = "en-US";

		/// <summary>
		/// Available languages
		/// </summary>
		public static readonly string[] AvailableLanguages = { "en-US", "zh-TW" };
		public static readonly string[] LanguageDisplayNames = { "English", "繁體中文" };

		/// <summary>
		/// Gets or sets the current language
		/// </summary>
		public static string CurrentLanguage {
			get { return _currentLanguage; }
			set {
				if (_currentLanguage != value) {
					_currentLanguage = value;
					LoadStrings();
					OnLanguageChanged();
				}
			}
		}

		/// <summary>
		/// Event fired when language changes
		/// </summary>
		public static event EventHandler LanguageChanged;

		private static void OnLanguageChanged() {
			if (LanguageChanged != null)
				LanguageChanged(null, EventArgs.Empty);
		}

		static LocalizationManager() {
			LoadStrings();
		}

		/// <summary>
		/// Initialize with saved language setting
		/// </summary>
		public static void Initialize(string language) {
			_currentLanguage = language;
			LoadStrings();
		}

		private static void LoadStrings() {
			_strings = new Dictionary<string, string>();

			if (_currentLanguage == "zh-TW") {
				LoadTraditionalChinese();
			}
			else {
				LoadEnglish();
			}
		}

		/// <summary>
		/// Gets a localized string by key
		/// </summary>
		public static string GetString(string key) {
			if (_strings == null)
				LoadStrings();

			string value;
			if (_strings.TryGetValue(key, out value))
				return value;

			return key; // Return key if not found
		}

		/// <summary>
		/// Shorthand method for GetString
		/// </summary>
		public static string S(string key) {
			return GetString(key);
		}

		#region English Strings
		private static void LoadEnglish() {
			// Main Menu - File
			_strings["Menu_File"] = "File";
			_strings["Menu_NewAct"] = "New Act";
			_strings["Menu_NewAct_Default"] = "Default (empty)";
			_strings["Menu_NewAct_HeadgearMale"] = "Headgear (male)";
			_strings["Menu_NewAct_HeadgearFemale"] = "Headgear (female)";
			_strings["Menu_NewAct_Monster"] = "Monster template";
			_strings["Menu_NewAct_Homunculus"] = "Homunculus template";
			_strings["Menu_NewAct_Weapon"] = "Weapon template";
			_strings["Menu_NewAct_NPC"] = "NPC template";
			_strings["Menu_Open"] = "Open...";
			_strings["Menu_OpenFromGrf"] = "Open from Grf...";
			_strings["Menu_OpenRecent"] = "Open recent";
			_strings["Menu_CloseAct"] = "Close Act";
			_strings["Menu_SelectAct"] = "Select Act";
			_strings["Menu_Save"] = "Save";
			_strings["Menu_SaveAs"] = "Save as...";
			_strings["Menu_SaveAsGarment"] = "Save as garment...";
			_strings["Menu_Settings"] = "Settings";
			_strings["Menu_About"] = "About...";
			_strings["Menu_Quit"] = "Quit";

			// Main Menu - Edit
			_strings["Menu_Edit"] = "Edit";
			_strings["Menu_Copy"] = "Copy";
			_strings["Menu_Paste"] = "Paste";
			_strings["Menu_Cut"] = "Cut";
			_strings["Menu_View"] = "View";
			_strings["Menu_KeepActionSelection"] = "Keep action selection";
			_strings["Menu_ShowAdjacentFrames"] = "Show the adjacent frames";

			// Main Menu - Anchors
			_strings["Menu_Anchors"] = "Anchors";
			_strings["Menu_ShowAnchors"] = "Show anchors";
			_strings["Menu_UseBodyAsBase"] = "Use body as base";
			_strings["Menu_UseBodyAsBase_Desc"] = "- Unchecked for headgears\n- Checked for garments/wings";
			_strings["Menu_Anchor"] = "Anchor";
			_strings["Menu_Anchor1"] = "Anchor 1";
			_strings["Menu_Anchor2"] = "Anchor 2";
			_strings["Menu_Anchor3"] = "Anchor 3";
			_strings["Menu_Anchor4"] = "Anchor 4";
			_strings["Menu_Anchor5"] = "Anchor 5";

			// Undo/Redo
			_strings["Undo_Action"] = "Undo {0} action";
			_strings["Redo_Action"] = "Redo {0} action";

			// Settings Dialog
			_strings["Settings_Title"] = "Settings";
			_strings["Settings_General"] = "General";
			_strings["Settings_EditorColors"] = "Editor colors";
			_strings["Settings_Mouse"] = "Mouse";
			_strings["Settings_Sound"] = "Sound";
			_strings["Settings_GifFormat"] = "Gif format";
			_strings["Settings_ShellIntegration"] = "Shell integration";
			_strings["Settings_Debugger"] = "Debugger";
			_strings["Settings_Shortcuts"] = "Shortcuts";
			_strings["Settings_Language"] = "Language";

			// Settings - General
			_strings["Settings_ReopenLatestFile"] = "Always reopen latest opened file";
			_strings["Settings_ReopenLatestFile_Tooltip"] = "If checked, when opening the application, the last opened sprite\nwill from the recent files menu will be opened.";
			_strings["Settings_ShowHorizontalGridLine"] = "Show horizontal grid line";
			_strings["Settings_ShowHorizontalGridLine_Tooltip"] = "Show or hide the horizontal grid line in the Frame Editor control.";
			_strings["Settings_ShowVerticalGridLine"] = "Show vertical grid line";
			_strings["Settings_ShowVerticalGridLine_Tooltip"] = "Show or hide the vertical grid line in the Frame Editor control.";
			_strings["Settings_RefreshLayerEditor"] = "Refresh layer editor while animations are playing";
			_strings["Settings_RefreshLayerEditor_Tooltip"] = "Disabling this feature will render the animations much faster.";
			_strings["Settings_UseAliasing"] = "Use aliasing for the selected layers' border";
			_strings["Settings_UseAliasing_Tooltip"] = "Turns anti-aliasing on or off for the selection border of the layers.";
			_strings["Settings_UseRealFrameInterval"] = "Use real frame interval instead of being rounded";
			_strings["Settings_UseRealFrameInterval_Tooltip"] = "Using an animation speed of 1, the delay between frames is 24ms officially. Act Editor rounds up this number to 25ms for simplicity. Checking this option uses 24ms instead.";
			_strings["Settings_DisplayEncoding"] = "Display encoding";
			_strings["Settings_DisplayEncoding_Tooltip"] = "Changes how the file names are shown when loading a GRF.";
			_strings["Settings_Theme"] = "Theme";
			_strings["Settings_Theme_Tooltip"] = "Determines Act Editor's UI style.";

			// Settings - Editor Colors
			_strings["Settings_PreviewPanelBgColor"] = "Preview panel background color";
			_strings["Settings_PreviewPanelBgColor_Tooltip"] = "Change the background color of the Frame Editor control.";
			_strings["Settings_GridLineHColor"] = "Grid line horizontal color";
			_strings["Settings_GridLineHColor_Tooltip"] = "Change the horizontal line color of the Frame Editor control.";
			_strings["Settings_GridLineVColor"] = "Grid line vertical color";
			_strings["Settings_GridLineVColor_Tooltip"] = "Change the vertical line color of the Frame Editor control.";
			_strings["Settings_SelectedSpriteBorderColor"] = "Selected sprite border color";
			_strings["Settings_SelectedSpriteBorderColor_Tooltip"] = "Change the border color of the selected sprite in the Editor control.";
			_strings["Settings_SelectedSpriteOverlayColor"] = "Selected sprite overlay color";
			_strings["Settings_SelectedSpriteOverlayColor_Tooltip"] = "Change the overlay color of the selected sprite in the Editor control.";
			_strings["Settings_SelectionBorderColor"] = "Selection border color";
			_strings["Settings_SelectionBorderColor_Tooltip"] = "Change the border color of the selection rectangle in the Editor control.";
			_strings["Settings_SelectionOverlayColor"] = "Selection overlay color";
			_strings["Settings_SelectionOverlayColor_Tooltip"] = "Change the overlay color of the selection rectangle in the Editor control.";
			_strings["Settings_AnchorSelectorColor"] = "Anchor selector color";
			_strings["Settings_AnchorSelectorColor_Tooltip"] = "Change the anchor line colors in the Sprite Editor control.";
			_strings["Settings_PreviewSpriteBgColor"] = "Preview sprite background color";
			_strings["Settings_PreviewSpriteBgColor_Tooltip"] = "Change the background color of Sprite Editor control.";

			// Settings - Mouse
			_strings["Settings_ZoomIn"] = "Zoom in";
			_strings["Settings_ZoomOut"] = "Zoom out";
			_strings["Settings_ScrollUp"] = "Scroll up";
			_strings["Settings_ScrollDown"] = "Scroll down";
			_strings["Settings_FixedScaling"] = "Fixed scaling";
			_strings["Settings_HorizontalScaling"] = "Horizontal scaling";
			_strings["Settings_VerticalScaling"] = "Vertical scaling";
			_strings["Settings_UnboundScaling"] = "Unbound scaling";
			_strings["Settings_Translate"] = "Translate";
			_strings["Settings_Rotate"] = "Rotate";
			_strings["Settings_PreviewPanelMove"] = "Preview panel move";
			_strings["Settings_CtrlAltLeftMouse"] = "Ctrl-Alt-Left Mouse Button";
			_strings["Settings_CtrlShiftLeftMouse"] = "Ctrl-Shift-Left Mouse Button";
			_strings["Settings_CtrlLeftMouse"] = "Ctrl-Left Mouse Button";
			_strings["Settings_LeftMouse"] = "Left Mouse Button";
			_strings["Settings_ShiftLeftMouse"] = "Shift-Left Mouse Button";
			_strings["Settings_RightMouse"] = "Right Mouse Button";

			// Settings - Sound
			_strings["Settings_ResourceFiles"] = "Resource files or folders (drop a GRF or a data folder) :";

			// Settings - Gif Format
			_strings["Settings_Uniform"] = "Uniform";
			_strings["Settings_Uniform_Tooltip"] = "Adds margin on each side of the printed frames to center them.\nAll frames will have the same width and height (recommended).";
			_strings["Settings_BackgroundColor"] = "Background color";
			_strings["Settings_BackgroundColor_Tooltip"] = "Change the background color for semi-transparent images. If your website\nhas a blue background, you might want to set this to blue as well.";
			_strings["Settings_GuidelinesColor"] = "Guidelines color";
			_strings["Settings_GuidelinesColor_Tooltip"] = "Change the guidelines color. The guidelines are simply the\nX-axis and Y-axis.";
			_strings["Settings_DelayFactor"] = "Delay factor";
			_strings["Settings_DelayFactor_Tooltip"] = "This is a multiplier value to change the speed of the animation.\nIf set to 2, the animation speed will be twice as slow.\nIf set to 0.5, the animation speed will be twice as fast.";
			_strings["Settings_Margin"] = "Margin";
			_strings["Settings_Margin_Tooltip"] = "Adds a margin around the animation. A minimum margin of 1\nmust be used.";
			_strings["Settings_HideSettingDialog"] = "Hide setting dialog when saving";
			_strings["Settings_HideSettingDialog_Tooltip"] = "Hides the settings dialog when saving a gif image.";

			// Settings - Shell Integration
			_strings["Settings_AssociateExtensions"] = "Associate these file extensions with Act Editor.";

			// Settings - Debugger
			_strings["Settings_LogExceptions"] = "Log any exceptions (debug.log)";
			_strings["Settings_ShowVersionDowngrade"] = "Show version downgrade error";

			// Settings - Shortcuts
			_strings["Settings_Reset"] = "Reset";
			_strings["Settings_ResetAllShortcuts"] = "Reset all shortcuts";
			_strings["Settings_Update"] = "Update";
			_strings["Settings_LookForNewShortcuts"] = "Look for new loaded shortcuts";
			_strings["Settings_Search"] = "Search";

			// Buttons
			_strings["Button_Ok"] = "Ok";
			_strings["Button_Cancel"] = "Cancel";
			_strings["Button_Apply"] = "Apply";
			_strings["Button_Close"] = "Close";
			_strings["Button_Export"] = "Export";
			_strings["Button_Import"] = "Import";
			_strings["Button_Browse"] = "Browse...";
			_strings["Button_Help"] = "Help";

			// Script Menu - Edit
			_strings["Script_SelectAll"] = "Select all";
			_strings["Script_DeselectAll"] = "Deselect all";
			_strings["Script_InvertSelection"] = "Invert selection";
			_strings["Script_BringToFront"] = "Bring to front";
			_strings["Script_BringToBack"] = "Bring to back";
			_strings["Script_EditSoundList"] = "Edit sound list...";
			_strings["Script_QuickPaletteEdit"] = "Quick palette edit...";
			_strings["Script_PaletteEditor"] = "Palette editor...";
			_strings["Script_ImportPalette"] = "Import palette...";
			_strings["Script_ClearPalette"] = "Clear palette";
			_strings["Script_SelectBackground"] = "Select background";

			// Script Menu - Action
			_strings["Script_CopyAction"] = "Copy action";
			_strings["Script_PasteAction"] = "Paste action";
			_strings["Script_AddActionTo"] = "Add action to...";
			_strings["Script_CopyActionReplace"] = "Copy action and replace to...";
			_strings["Script_DeleteAction"] = "Delete action";
			_strings["Script_SwitchActionTo"] = "Switch action to...";
			_strings["Script_EditFrameAnchor"] = "Edit frame anchor position";
			_strings["Script_MirrorActionLeftRight"] = "Mirror action from\nleft/right to right/left";
			_strings["Script_MoveLayersToBack"] = "Move layers to back";
			_strings["Script_MoveLayersToFront"] = "Move layers to front";

			// Script Menu - Frame
			_strings["Script_AddFrameTo"] = "Add frame to...";
			_strings["Script_CopyFrameReplace"] = "Copy frame and replace to...";
			_strings["Script_DeleteFrame"] = "Delete frame";
			_strings["Script_DuplicateFrames"] = "Duplicate frames...";
			_strings["Script_SwitchFrameTo"] = "Switch frame to...";

			// Script Menu - Anchor
			_strings["Script_AdjustAnchorsMale"] = "Adjust anchors (male)";
			_strings["Script_AdjustAnchorsFemale"] = "Adjust anchors (female)";
			_strings["Script_SetAnchors"] = "Set anchors";
			_strings["Script_SetDefaultMale"] = "Set default (male)";
			_strings["Script_SetDefaultFemale"] = "Set default (female)";
			_strings["Script_SetupHead"] = "Setup Head...";
			_strings["Script_SetupHeadgear"] = "Setup Headgear...";
			_strings["Script_SetupGarment"] = "Setup Garment...";

			// Script Menu - Animation
			_strings["Script_MirrorHorizontal"] = "Mirror horizontal";
			_strings["Script_MirrorVertical"] = "Mirror vertical";
			_strings["Script_ReverseAnimation"] = "Reverse animation";
			_strings["Script_GenerateFade"] = "Generate fade animation";
			_strings["Script_GenerateDamage"] = "Generate receiving damage animation";
			_strings["Script_Breathing"] = "Breathing [Palooza]";
			_strings["Script_StrokeSilhouette"] = "Stroke silhouette [Palooza]";
			_strings["Script_RotationCopyBottomToBottomRight"] = "Rotation copy from\nbottom to bottom right";
			_strings["Script_RotationCopyBottomRightToBottom"] = "Rotation copy from\nbottom right to bottom (common)";
			_strings["Script_RotationCopyBottomLeftToBottom"] = "Rotation copy from\nbottom left to bottom";
			_strings["Script_RotationCopyBottomToBottomLeft"] = "Rotation copy from\nbottom to bottom left (common)";
			_strings["Script_InterpolateFrames"] = "Interpolate frames";
			_strings["Script_InterpolateSelectedLayers"] = "Interpolate selected layers";
			_strings["Script_AdvancedInterpolation"] = "Advanced interpolation";

			// Script Menu - Effects
			_strings["Script_AdjustFromFile"] = "Adjust from file...";
			_strings["Script_SetFromFile"] = "Set from file...";
			_strings["Script_AdvancedEdit"] = "Advanced edit...";

			// Script Menu - Script
			_strings["Script_ScriptRunner"] = "Script Runner...";
			_strings["Script_ReloadScripts"] = "Reload scripts";
			_strings["Script_OpenScriptsFolder"] = "Open scripts folder";
			_strings["Script_BatchScript"] = "Batch script...";
			_strings["Script_AddSpriteToAllFrames"] = "Add sprite to all frames...";

			// Script Menu - File
			_strings["Script_ExportAllSprites"] = "Export all sprites...";
			_strings["Script_ExportAllSpritesAdv"] = "Export all sprites (adv)...";

			// Groups
			_strings["Group_Edit"] = "Edit";
			_strings["Group_Action"] = "Action";
			_strings["Group_Frame"] = "Frame";
			_strings["Group_Anchor"] = "Anchor";
			_strings["Group_Anchors"] = "Anchors";
			_strings["Group_AnchorsSetAnchors"] = "Anchors/Set anchors";
			_strings["Group_AnchorsAdjustAnchors"] = "Anchors/Adjust anchors";
			_strings["Group_Animation"] = "Animation";
			_strings["Group_Effects"] = "Effects";
			_strings["Group_Script"] = "Script";
			_strings["Group_Scripts"] = "Scripts";
			_strings["Group_File"] = "File";

			// Frame helper
			_strings["Frame_CopyFromCurrentFrame"] = "Copy from the currently selected frame";

			// Dialogs
			_strings["Dialog_ActionInsert"] = "Action insert";
			_strings["Dialog_FrameInsert"] = "Frame insert";
			_strings["Dialog_GifSaving"] = "Gif saving";
			_strings["Dialog_ExtractSprite"] = "Extract sprite";
			_strings["Dialog_Interpolate"] = "Interpolate";
			_strings["Dialog_ScriptRunner"] = "Script Runner";
			_strings["Dialog_BatchScript"] = "Batch script";
			_strings["Dialog_SoundEdit"] = "Sound edit";
			_strings["Dialog_EffectPreview"] = "Effect preview";
			_strings["Dialog_SaveGarment"] = "Save as garment";
			_strings["Dialog_HeadEditor"] = "Head editor";
			_strings["Dialog_SpriteConverter"] = "Sprite converter";
			_strings["Dialog_StyleEditor"] = "Style editor";
			_strings["Dialog_Usage"] = "Usage";

			// Export Sprite Dialog
			_strings["Export_SourceDirectory"] = "Source directory";
			_strings["Export_OutputDirectory"] = "Output directory";
			_strings["Export_CurrentSprite"] = "Current sprite";
			_strings["Export_CurrentFolder"] = "Current folder";
			_strings["Export_Preset"] = "Preset...";

			// Batch Script Dialog
			_strings["BatchScript_SourceDirectory"] = "Source directory";
			_strings["BatchScript_SourceScript"] = "Source script";
			_strings["BatchScript_UseCurrentFolder"] = "Use current folder";
			_strings["BatchScript_Script"] = "Script...";
			_strings["BatchScript_Execute"] = "Execute";

			// Script Runner Dialog
			_strings["ScriptRunner_Script"] = "Script";
			_strings["ScriptRunner_Run"] = "Run";
			_strings["ScriptRunner_New"] = "New";
			_strings["ScriptRunner_Open"] = "Open...";
			_strings["ScriptRunner_OpenRecent"] = "Open recent";
			_strings["ScriptRunner_Save"] = "Save...";
			_strings["ScriptRunner_ErrorConsole"] = "Error console";

			// GIF Dialog
			_strings["Gif_FrameIndexFrom"] = "Frame index from";
			_strings["Gif_FrameIndexTo"] = "Frame index to";
			_strings["Gif_SpeedInterval"] = "Speed (interval in ms)";
			_strings["Gif_DoNotShowAgain"] = "Do not show this dialog again (available in the Settings page)";
			_strings["Gif_Preview"] = "Preview";

			// Action/Frame Insert Dialog
			_strings["Insert_EditMode"] = "Edit mode : ";
			_strings["Insert_Delete"] = "Delete";
			_strings["Insert_CopyTo"] = "Copy to";
			_strings["Insert_InsertTo"] = "Insert to";
			_strings["Insert_MoveTo"] = "Move to";
			_strings["Insert_SwitchTo"] = "Switch to";
			_strings["Insert_StartIndex"] = "Start index";
			_strings["Insert_Count"] = "Count";
			_strings["Insert_DestinationIndex"] = "Destination index";
			_strings["Insert_SetToLastIndex"] = "Set to last index";
			_strings["Insert_CopyFromCurrentlySelected"] = "Copy from currently selected";
			_strings["Insert_Frame"] = "Frame";
			_strings["Insert_Layers"] = "Layers";
			_strings["Insert_StartFrame"] = "Start frame";
			_strings["Insert_TargetFrame"] = "Target frame";
			_strings["Insert_FramesToAdd"] = "Frames to add";
			_strings["Insert_LayerIndexes"] = "Layer indexes";
			_strings["Insert_InterpolationProperties"] = "Interpolation properties";
			_strings["Insert_LayerTolerance"] = "Layer tolerance";

			// Interpolate Dialog
			_strings["Interpolate_Offsets"] = "Offsets";
			_strings["Interpolate_Scale"] = "Scale";
			_strings["Interpolate_Angle"] = "Angle";
			_strings["Interpolate_Color"] = "Color";
			_strings["Interpolate_Mirror"] = "Mirror";
			_strings["Interpolate_Ease"] = "Ease";
			_strings["Interpolate_Range"] = "Range";
			_strings["Interpolate_Tolerance"] = "Tolerance";

			// Search Panel
			_strings["Search_Options"] = "Search options";
			_strings["Search_UseRegex"] = "Use Regular Expression";
			_strings["Search_MatchWholeWords"] = "Match Whole Words";
			_strings["Search_MatchCase"] = "Match Case";
			_strings["Search_Find"] = "Find...";
			_strings["Search_Replace"] = "Replace...";

			// Layer Editor
			_strings["Layer_SpriteIndex"] = "Sprite index";
			_strings["Layer_OffsetX"] = "Offset X";
			_strings["Layer_OffsetY"] = "Offset Y";
			_strings["Layer_Mirror"] = "Mirror";
			_strings["Layer_Rotation"] = "Rotation";
			_strings["Layer_ScaleX"] = "Scale X";
			_strings["Layer_ScaleY"] = "Scale Y";
			_strings["Layer_Color"] = "Color";

			// Frame/Action Selector
			_strings["Selector_Action"] = "Action";
			_strings["Selector_Frame"] = "Frame";
			_strings["Selector_Speed"] = "Speed";
			_strings["Selector_Play"] = "Play";
			_strings["Selector_Stop"] = "Stop";

			// Messages
			_strings["Msg_FileNotFound"] = "File not found";
			_strings["Msg_SaveSuccess"] = "File saved successfully";
			_strings["Msg_SaveFailed"] = "Failed to save file";
			_strings["Msg_ConfirmDelete"] = "Are you sure you want to delete?";
			_strings["Msg_ConfirmOverwrite"] = "File already exists. Overwrite?";
			_strings["Msg_InvalidInput"] = "Invalid input";
			_strings["Msg_OperationComplete"] = "Operation completed";
			_strings["Msg_Error"] = "Error";
			_strings["Msg_Warning"] = "Warning";
			_strings["Msg_Information"] = "Information";
			_strings["Msg_RestartRequired"] = "Please restart the application for the language change to take effect.";

			// Palette Editor
			_strings["Palette_AdjustColor"] = "Adjust color";
			_strings["Palette_GradientEdit"] = "Gradient edit";
			_strings["Palette_MultiColor"] = "Multi color";
			_strings["Palette_SingleColorEdit"] = "Single color edit";

			// Tools
			_strings["Tool_GrfExplorer"] = "GRF Explorer";
			_strings["Tool_PaletteEditor"] = "Palette Editor";
			_strings["Tool_PreviewSheet"] = "Preview sheet";
		}
		#endregion

		#region Traditional Chinese Strings
		private static void LoadTraditionalChinese() {
			// Main Menu - File
			_strings["Menu_File"] = "檔案";
			_strings["Menu_NewAct"] = "新增動作檔";
			_strings["Menu_NewAct_Default"] = "預設（空白）";
			_strings["Menu_NewAct_HeadgearMale"] = "頭飾（男性）";
			_strings["Menu_NewAct_HeadgearFemale"] = "頭飾（女性）";
			_strings["Menu_NewAct_Monster"] = "怪物範本";
			_strings["Menu_NewAct_Homunculus"] = "生命體範本";
			_strings["Menu_NewAct_Weapon"] = "武器範本";
			_strings["Menu_NewAct_NPC"] = "NPC 範本";
			_strings["Menu_Open"] = "開啟...";
			_strings["Menu_OpenFromGrf"] = "從 Grf 開啟...";
			_strings["Menu_OpenRecent"] = "最近開啟的檔案";
			_strings["Menu_CloseAct"] = "關閉動作檔";
			_strings["Menu_SelectAct"] = "選擇動作檔";
			_strings["Menu_Save"] = "儲存";
			_strings["Menu_SaveAs"] = "另存新檔...";
			_strings["Menu_SaveAsGarment"] = "另存為披風...";
			_strings["Menu_Settings"] = "設定";
			_strings["Menu_About"] = "關於...";
			_strings["Menu_Quit"] = "離開";

			// Main Menu - Edit
			_strings["Menu_Edit"] = "編輯";
			_strings["Menu_Copy"] = "複製";
			_strings["Menu_Paste"] = "貼上";
			_strings["Menu_Cut"] = "剪下";
			_strings["Menu_View"] = "檢視";
			_strings["Menu_KeepActionSelection"] = "保持動作選取";
			_strings["Menu_ShowAdjacentFrames"] = "顯示相鄰幀";

			// Main Menu - Anchors
			_strings["Menu_Anchors"] = "錨點";
			_strings["Menu_ShowAnchors"] = "顯示錨點";
			_strings["Menu_UseBodyAsBase"] = "使用身體作為基準";
			_strings["Menu_UseBodyAsBase_Desc"] = "- 頭飾時取消勾選\n- 披風/翅膀時勾選";
			_strings["Menu_Anchor"] = "錨點";
			_strings["Menu_Anchor1"] = "錨點 1";
			_strings["Menu_Anchor2"] = "錨點 2";
			_strings["Menu_Anchor3"] = "錨點 3";
			_strings["Menu_Anchor4"] = "錨點 4";
			_strings["Menu_Anchor5"] = "錨點 5";

			// Undo/Redo
			_strings["Undo_Action"] = "復原 {0} 動作";
			_strings["Redo_Action"] = "重做 {0} 動作";

			// Settings Dialog
			_strings["Settings_Title"] = "設定";
			_strings["Settings_General"] = "一般";
			_strings["Settings_EditorColors"] = "編輯器顏色";
			_strings["Settings_Mouse"] = "滑鼠";
			_strings["Settings_Sound"] = "音效";
			_strings["Settings_GifFormat"] = "GIF 格式";
			_strings["Settings_ShellIntegration"] = "系統整合";
			_strings["Settings_Debugger"] = "偵錯工具";
			_strings["Settings_Shortcuts"] = "快捷鍵";
			_strings["Settings_Language"] = "語言";

			// Settings - General
			_strings["Settings_ReopenLatestFile"] = "啟動時自動開啟上次的檔案";
			_strings["Settings_ReopenLatestFile_Tooltip"] = "勾選後，啟動應用程式時會自動開啟\n最近檔案清單中的最後一個檔案。";
			_strings["Settings_ShowHorizontalGridLine"] = "顯示水平格線";
			_strings["Settings_ShowHorizontalGridLine_Tooltip"] = "在幀編輯器中顯示或隱藏水平格線。";
			_strings["Settings_ShowVerticalGridLine"] = "顯示垂直格線";
			_strings["Settings_ShowVerticalGridLine_Tooltip"] = "在幀編輯器中顯示或隱藏垂直格線。";
			_strings["Settings_RefreshLayerEditor"] = "播放動畫時重新整理圖層編輯器";
			_strings["Settings_RefreshLayerEditor_Tooltip"] = "停用此功能可使動畫播放更流暢。";
			_strings["Settings_UseAliasing"] = "選取圖層邊框使用反鋸齒";
			_strings["Settings_UseAliasing_Tooltip"] = "開啟或關閉圖層選取邊框的反鋸齒效果。";
			_strings["Settings_UseRealFrameInterval"] = "使用精確的幀間隔時間";
			_strings["Settings_UseRealFrameInterval_Tooltip"] = "動畫速度為 1 時，官方的幀間隔為 24 毫秒。Act Editor 預設使用 25 毫秒。勾選此選項可使用 24 毫秒。";
			_strings["Settings_DisplayEncoding"] = "顯示編碼";
			_strings["Settings_DisplayEncoding_Tooltip"] = "變更載入 GRF 時檔案名稱的顯示方式。";
			_strings["Settings_Theme"] = "佈景主題";
			_strings["Settings_Theme_Tooltip"] = "設定 Act Editor 的介面樣式。";

			// Settings - Editor Colors
			_strings["Settings_PreviewPanelBgColor"] = "預覽面板背景色";
			_strings["Settings_PreviewPanelBgColor_Tooltip"] = "變更幀編輯器的背景顏色。";
			_strings["Settings_GridLineHColor"] = "水平格線顏色";
			_strings["Settings_GridLineHColor_Tooltip"] = "變更幀編輯器的水平線顏色。";
			_strings["Settings_GridLineVColor"] = "垂直格線顏色";
			_strings["Settings_GridLineVColor_Tooltip"] = "變更幀編輯器的垂直線顏色。";
			_strings["Settings_SelectedSpriteBorderColor"] = "選取精靈邊框顏色";
			_strings["Settings_SelectedSpriteBorderColor_Tooltip"] = "變更編輯器中選取精靈的邊框顏色。";
			_strings["Settings_SelectedSpriteOverlayColor"] = "選取精靈覆蓋顏色";
			_strings["Settings_SelectedSpriteOverlayColor_Tooltip"] = "變更編輯器中選取精靈的覆蓋顏色。";
			_strings["Settings_SelectionBorderColor"] = "選取框邊框顏色";
			_strings["Settings_SelectionBorderColor_Tooltip"] = "變更編輯器中選取框的邊框顏色。";
			_strings["Settings_SelectionOverlayColor"] = "選取框覆蓋顏色";
			_strings["Settings_SelectionOverlayColor_Tooltip"] = "變更編輯器中選取框的覆蓋顏色。";
			_strings["Settings_AnchorSelectorColor"] = "錨點選取器顏色";
			_strings["Settings_AnchorSelectorColor_Tooltip"] = "變更精靈編輯器中錨點線的顏色。";
			_strings["Settings_PreviewSpriteBgColor"] = "精靈預覽背景色";
			_strings["Settings_PreviewSpriteBgColor_Tooltip"] = "變更精靈編輯器的背景顏色。";

			// Settings - Mouse
			_strings["Settings_ZoomIn"] = "放大";
			_strings["Settings_ZoomOut"] = "縮小";
			_strings["Settings_ScrollUp"] = "向上滾動";
			_strings["Settings_ScrollDown"] = "向下滾動";
			_strings["Settings_FixedScaling"] = "固定縮放";
			_strings["Settings_HorizontalScaling"] = "水平縮放";
			_strings["Settings_VerticalScaling"] = "垂直縮放";
			_strings["Settings_UnboundScaling"] = "自由縮放";
			_strings["Settings_Translate"] = "移動";
			_strings["Settings_Rotate"] = "旋轉";
			_strings["Settings_PreviewPanelMove"] = "預覽面板移動";
			_strings["Settings_CtrlAltLeftMouse"] = "Ctrl+Alt+滑鼠左鍵";
			_strings["Settings_CtrlShiftLeftMouse"] = "Ctrl+Shift+滑鼠左鍵";
			_strings["Settings_CtrlLeftMouse"] = "Ctrl+滑鼠左鍵";
			_strings["Settings_LeftMouse"] = "滑鼠左鍵";
			_strings["Settings_ShiftLeftMouse"] = "Shift+滑鼠左鍵";
			_strings["Settings_RightMouse"] = "滑鼠右鍵";

			// Settings - Sound
			_strings["Settings_ResourceFiles"] = "資源檔案或資料夾（拖曳 GRF 或 data 資料夾）：";

			// Settings - Gif Format
			_strings["Settings_Uniform"] = "統一大小";
			_strings["Settings_Uniform_Tooltip"] = "在每幀周圍加入邊距使其置中。\n所有幀將具有相同的寬度和高度（建議）。";
			_strings["Settings_BackgroundColor"] = "背景顏色";
			_strings["Settings_BackgroundColor_Tooltip"] = "變更半透明圖片的背景顏色。如果您的網站\n背景是藍色，您可能也想設定為藍色。";
			_strings["Settings_GuidelinesColor"] = "參考線顏色";
			_strings["Settings_GuidelinesColor_Tooltip"] = "變更參考線顏色。參考線即為\nX 軸和 Y 軸。";
			_strings["Settings_DelayFactor"] = "延遲倍數";
			_strings["Settings_DelayFactor_Tooltip"] = "這是用來改變動畫速度的倍數值。\n設為 2 時，動畫速度會變慢一倍。\n設為 0.5 時，動畫速度會變快一倍。";
			_strings["Settings_Margin"] = "邊距";
			_strings["Settings_Margin_Tooltip"] = "在動畫周圍加入邊距。\n邊距至少需要 1。";
			_strings["Settings_HideSettingDialog"] = "儲存時隱藏設定對話框";
			_strings["Settings_HideSettingDialog_Tooltip"] = "儲存 GIF 圖片時隱藏設定對話框。";

			// Settings - Shell Integration
			_strings["Settings_AssociateExtensions"] = "將這些副檔名與 Act Editor 建立關聯。";

			// Settings - Debugger
			_strings["Settings_LogExceptions"] = "記錄所有例外（debug.log）";
			_strings["Settings_ShowVersionDowngrade"] = "顯示版本降級錯誤";

			// Settings - Shortcuts
			_strings["Settings_Reset"] = "重設";
			_strings["Settings_ResetAllShortcuts"] = "重設所有快捷鍵";
			_strings["Settings_Update"] = "更新";
			_strings["Settings_LookForNewShortcuts"] = "搜尋新載入的快捷鍵";
			_strings["Settings_Search"] = "搜尋";

			// Buttons
			_strings["Button_Ok"] = "確定";
			_strings["Button_Cancel"] = "取消";
			_strings["Button_Apply"] = "套用";
			_strings["Button_Close"] = "關閉";
			_strings["Button_Export"] = "匯出";
			_strings["Button_Import"] = "匯入";
			_strings["Button_Browse"] = "瀏覽...";
			_strings["Button_Help"] = "說明";

			// Script Menu - Edit
			_strings["Script_SelectAll"] = "全選";
			_strings["Script_DeselectAll"] = "取消全選";
			_strings["Script_InvertSelection"] = "反轉選取";
			_strings["Script_BringToFront"] = "移至最上層";
			_strings["Script_BringToBack"] = "移至最下層";
			_strings["Script_EditSoundList"] = "編輯音效清單...";
			_strings["Script_QuickPaletteEdit"] = "快速調色盤編輯...";
			_strings["Script_PaletteEditor"] = "調色盤編輯器...";
			_strings["Script_ImportPalette"] = "匯入調色盤...";
			_strings["Script_ClearPalette"] = "清除調色盤";
			_strings["Script_SelectBackground"] = "選擇背景";

			// Script Menu - Action
			_strings["Script_CopyAction"] = "複製動作";
			_strings["Script_PasteAction"] = "貼上動作";
			_strings["Script_AddActionTo"] = "新增動作至...";
			_strings["Script_CopyActionReplace"] = "複製動作並取代至...";
			_strings["Script_DeleteAction"] = "刪除動作";
			_strings["Script_SwitchActionTo"] = "切換動作至...";
			_strings["Script_EditFrameAnchor"] = "編輯幀錨點位置";
			_strings["Script_MirrorActionLeftRight"] = "從左/右鏡射動作\n至右/左";
			_strings["Script_MoveLayersToBack"] = "將圖層移至後方";
			_strings["Script_MoveLayersToFront"] = "將圖層移至前方";

			// Script Menu - Frame
			_strings["Script_AddFrameTo"] = "新增幀至...";
			_strings["Script_CopyFrameReplace"] = "複製幀並取代至...";
			_strings["Script_DeleteFrame"] = "刪除幀";
			_strings["Script_DuplicateFrames"] = "複製幀...";
			_strings["Script_SwitchFrameTo"] = "切換幀至...";

			// Script Menu - Anchor
			_strings["Script_AdjustAnchorsMale"] = "調整錨點（男性）";
			_strings["Script_AdjustAnchorsFemale"] = "調整錨點（女性）";
			_strings["Script_SetAnchors"] = "設定錨點";
			_strings["Script_SetDefaultMale"] = "設定預設值（男性）";
			_strings["Script_SetDefaultFemale"] = "設定預設值（女性）";
			_strings["Script_SetupHead"] = "設定頭部...";
			_strings["Script_SetupHeadgear"] = "設定頭飾...";
			_strings["Script_SetupGarment"] = "設定披風...";

			// Script Menu - Animation
			_strings["Script_MirrorHorizontal"] = "水平翻轉";
			_strings["Script_MirrorVertical"] = "垂直翻轉";
			_strings["Script_ReverseAnimation"] = "反轉動畫";
			_strings["Script_GenerateFade"] = "產生淡出動畫";
			_strings["Script_GenerateDamage"] = "產生受擊動畫";
			_strings["Script_Breathing"] = "呼吸效果 [Palooza]";
			_strings["Script_StrokeSilhouette"] = "描邊輪廓 [Palooza]";
			_strings["Script_RotationCopyBottomToBottomRight"] = "旋轉複製從\n下方至右下方";
			_strings["Script_RotationCopyBottomRightToBottom"] = "旋轉複製從\n右下方至下方（常用）";
			_strings["Script_RotationCopyBottomLeftToBottom"] = "旋轉複製從\n左下方至下方";
			_strings["Script_RotationCopyBottomToBottomLeft"] = "旋轉複製從\n下方至左下方（常用）";
			_strings["Script_InterpolateFrames"] = "內插幀";
			_strings["Script_InterpolateSelectedLayers"] = "內插選取的圖層";
			_strings["Script_AdvancedInterpolation"] = "進階內插";

			// Script Menu - Effects
			_strings["Script_AdjustFromFile"] = "從檔案調整...";
			_strings["Script_SetFromFile"] = "從檔案設定...";
			_strings["Script_AdvancedEdit"] = "進階編輯...";

			// Script Menu - Script
			_strings["Script_ScriptRunner"] = "腳本執行器...";
			_strings["Script_ReloadScripts"] = "重新載入腳本";
			_strings["Script_OpenScriptsFolder"] = "開啟腳本資料夾";
			_strings["Script_BatchScript"] = "批次腳本...";
			_strings["Script_AddSpriteToAllFrames"] = "新增精靈至所有幀...";

			// Script Menu - File
			_strings["Script_ExportAllSprites"] = "匯出所有精靈...";
			_strings["Script_ExportAllSpritesAdv"] = "匯出所有精靈（進階）...";

			// Groups
			_strings["Group_Edit"] = "編輯";
			_strings["Group_Action"] = "動作";
			_strings["Group_Frame"] = "幀";
			_strings["Group_Anchor"] = "錨點";
			_strings["Group_Anchors"] = "錨點";
			_strings["Group_AnchorsSetAnchors"] = "錨點/設定錨點";
			_strings["Group_AnchorsAdjustAnchors"] = "錨點/調整錨點";
			_strings["Group_Animation"] = "動畫";
			_strings["Group_Effects"] = "效果";
			_strings["Group_Script"] = "腳本";
			_strings["Group_Scripts"] = "腳本";
			_strings["Group_File"] = "檔案";

			// Frame helper
			_strings["Frame_CopyFromCurrentFrame"] = "從目前選取的幀複製";

			// Dialogs
			_strings["Dialog_ActionInsert"] = "插入動作";
			_strings["Dialog_FrameInsert"] = "插入幀";
			_strings["Dialog_GifSaving"] = "儲存 GIF";
			_strings["Dialog_ExtractSprite"] = "擷取精靈";
			_strings["Dialog_Interpolate"] = "內插補點";
			_strings["Dialog_ScriptRunner"] = "腳本執行器";
			_strings["Dialog_BatchScript"] = "批次腳本";
			_strings["Dialog_SoundEdit"] = "編輯音效";
			_strings["Dialog_EffectPreview"] = "效果預覽";
			_strings["Dialog_SaveGarment"] = "另存為披風";
			_strings["Dialog_HeadEditor"] = "頭部編輯器";
			_strings["Dialog_SpriteConverter"] = "精靈轉換器";
			_strings["Dialog_StyleEditor"] = "樣式編輯器";
			_strings["Dialog_Usage"] = "使用說明";

			// Export Sprite Dialog
			_strings["Export_SourceDirectory"] = "來源目錄";
			_strings["Export_OutputDirectory"] = "輸出目錄";
			_strings["Export_CurrentSprite"] = "目前的精靈";
			_strings["Export_CurrentFolder"] = "目前的資料夾";
			_strings["Export_Preset"] = "預設值...";

			// Batch Script Dialog
			_strings["BatchScript_SourceDirectory"] = "來源目錄";
			_strings["BatchScript_SourceScript"] = "來源腳本";
			_strings["BatchScript_UseCurrentFolder"] = "使用目前的資料夾";
			_strings["BatchScript_Script"] = "腳本...";
			_strings["BatchScript_Execute"] = "執行";

			// Script Runner Dialog
			_strings["ScriptRunner_Script"] = "腳本";
			_strings["ScriptRunner_Run"] = "執行";
			_strings["ScriptRunner_New"] = "新增";
			_strings["ScriptRunner_Open"] = "開啟...";
			_strings["ScriptRunner_OpenRecent"] = "最近開啟";
			_strings["ScriptRunner_Save"] = "儲存...";
			_strings["ScriptRunner_ErrorConsole"] = "錯誤主控台";

			// GIF Dialog
			_strings["Gif_FrameIndexFrom"] = "起始幀索引";
			_strings["Gif_FrameIndexTo"] = "結束幀索引";
			_strings["Gif_SpeedInterval"] = "速度（間隔毫秒）";
			_strings["Gif_DoNotShowAgain"] = "不再顯示此對話框（可在設定頁面中調整）";
			_strings["Gif_Preview"] = "預覽";

			// Action/Frame Insert Dialog
			_strings["Insert_EditMode"] = "編輯模式：";
			_strings["Insert_Delete"] = "刪除";
			_strings["Insert_CopyTo"] = "複製至";
			_strings["Insert_InsertTo"] = "插入至";
			_strings["Insert_MoveTo"] = "移動至";
			_strings["Insert_SwitchTo"] = "切換至";
			_strings["Insert_StartIndex"] = "起始索引";
			_strings["Insert_Count"] = "數量";
			_strings["Insert_DestinationIndex"] = "目標索引";
			_strings["Insert_SetToLastIndex"] = "設為最後索引";
			_strings["Insert_CopyFromCurrentlySelected"] = "從目前選取複製";
			_strings["Insert_Frame"] = "幀";
			_strings["Insert_Layers"] = "圖層";
			_strings["Insert_StartFrame"] = "起始幀";
			_strings["Insert_TargetFrame"] = "目標幀";
			_strings["Insert_FramesToAdd"] = "要新增的幀數";
			_strings["Insert_LayerIndexes"] = "圖層索引";
			_strings["Insert_InterpolationProperties"] = "內插屬性";
			_strings["Insert_LayerTolerance"] = "圖層容差";

			// Interpolate Dialog
			_strings["Interpolate_Offsets"] = "偏移";
			_strings["Interpolate_Scale"] = "縮放";
			_strings["Interpolate_Angle"] = "角度";
			_strings["Interpolate_Color"] = "顏色";
			_strings["Interpolate_Mirror"] = "鏡像";
			_strings["Interpolate_Ease"] = "緩動";
			_strings["Interpolate_Range"] = "範圍";
			_strings["Interpolate_Tolerance"] = "容差";

			// Search Panel
			_strings["Search_Options"] = "搜尋選項";
			_strings["Search_UseRegex"] = "使用正規表示式";
			_strings["Search_MatchWholeWords"] = "全字比對";
			_strings["Search_MatchCase"] = "區分大小寫";
			_strings["Search_Find"] = "尋找...";
			_strings["Search_Replace"] = "取代...";

			// Layer Editor
			_strings["Layer_SpriteIndex"] = "精靈索引";
			_strings["Layer_OffsetX"] = "X 偏移";
			_strings["Layer_OffsetY"] = "Y 偏移";
			_strings["Layer_Mirror"] = "鏡像";
			_strings["Layer_Rotation"] = "旋轉";
			_strings["Layer_ScaleX"] = "X 縮放";
			_strings["Layer_ScaleY"] = "Y 縮放";
			_strings["Layer_Color"] = "顏色";

			// Frame/Action Selector
			_strings["Selector_Action"] = "動作";
			_strings["Selector_Frame"] = "幀";
			_strings["Selector_Speed"] = "速度";
			_strings["Selector_Play"] = "播放";
			_strings["Selector_Stop"] = "停止";

			// Messages
			_strings["Msg_FileNotFound"] = "找不到檔案";
			_strings["Msg_SaveSuccess"] = "檔案儲存成功";
			_strings["Msg_SaveFailed"] = "檔案儲存失敗";
			_strings["Msg_ConfirmDelete"] = "確定要刪除嗎？";
			_strings["Msg_ConfirmOverwrite"] = "檔案已存在，是否覆蓋？";
			_strings["Msg_InvalidInput"] = "輸入無效";
			_strings["Msg_OperationComplete"] = "操作完成";
			_strings["Msg_Error"] = "錯誤";
			_strings["Msg_Warning"] = "警告";
			_strings["Msg_Information"] = "資訊";
			_strings["Msg_RestartRequired"] = "請重新啟動應用程式以套用語言變更。";

			// Palette Editor
			_strings["Palette_AdjustColor"] = "調整顏色";
			_strings["Palette_GradientEdit"] = "漸層編輯";
			_strings["Palette_MultiColor"] = "多重顏色";
			_strings["Palette_SingleColorEdit"] = "單一顏色編輯";

			// Tools
			_strings["Tool_GrfExplorer"] = "GRF 瀏覽器";
			_strings["Tool_PaletteEditor"] = "調色盤編輯器";
			_strings["Tool_PreviewSheet"] = "預覽表";
		}
		#endregion
	}
}

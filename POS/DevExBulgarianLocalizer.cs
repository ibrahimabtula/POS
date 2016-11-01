
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraPivotGrid.Localization;
namespace POS
{
    public class DevExBulgarianLocalizer : GridLocalizer
    {
        public override string GetLocalizedString(GridStringId id)
        {
            switch (id)
            {
                // ...
                case GridStringId.GridGroupPanelText:
                    return "Добави колона за групиране";
                case GridStringId.MenuFooterCountGroupFormat:
                    return "{0} бл.";                case GridStringId.MenuColumnRemoveColumn:                    return "Премахни тази колона";                case GridStringId.MenuGroupPanelHide:                    return "Скрий панела за групиране";                case GridStringId.MenuGroupPanelShow:                    return "Покажи панела за групиране";
                case GridStringId.PopupFilterAll:
                    return "Покажи всички";
                case GridStringId.PopupFilterCustom:
                    return "[Потрбителски филтър]";
                case GridStringId.PopupFilterBlanks:
                    return "[Празни]";
                case GridStringId.PopupFilterNonBlanks:
                    return "[Не празни]";
                case GridStringId.FilterPanelCustomizeButton:
                    return "Редактирай филтъра";
                case GridStringId.FilterBuilderOkButton:
                    return "ДА";
                case GridStringId.FilterBuilderCancelButton:
                    return "ОТКАЗ";
                case GridStringId.FilterBuilderApplyButton:
                    return "ПРИЛОЖИ";
                case GridStringId.FilterBuilderCaption:
                    return "Редактиране на филтър";
                case GridStringId.CustomFilterDialogConditionEQU:
                    return "Равно на";
                case GridStringId.CustomFilterDialogConditionNEQ:
                    return "Не равно на";
                case GridStringId.CustomFilterDialogConditionGT:
                    return "По-голямо от";
                case GridStringId.CustomFilterDialogConditionGTE:
                    return "По-голямо или равно на";
                case GridStringId.CustomFilterDialogConditionLike:
                    return "Прилича на";
                case GridStringId.CustomFilterDialogConditionLT:
                    return "По-малко от";
                case GridStringId.CustomFilterDialogConditionLTE:
                    return "По-малко или равно на";
                case GridStringId.CustomFilterDialogConditionNotLike:
                    return "Не прилича на";
                case GridStringId.CustomFilterDialogConditionBlanks:
                    return "Празни";
                case GridStringId.CustomFilterDialogConditionNonBlanks:
                    return "Не празни";
                case GridStringId.CustomFilterDialogOkButton:
                    return "ДА";
                case GridStringId.CustomFilterDialogCancelButton:
                    return "ОТКАЗ";
                case GridStringId.CustomFilterDialogCaption:
                    return "Филтър за колона";
                case GridStringId.CustomFilterDialogFormCaption:
                    return "Задаване на филтър";
                case GridStringId.CustomFilterDialogRadioOr:
                    return "ИЛИ";
                case GridStringId.CustomFilterDialogRadioAnd:
                    return "И";
                case GridStringId.CardViewQuickCustomizationButton:
                    return "**";
                case GridStringId.MenuColumnSortAscending:
                    return "Сортиране във възходящ ред";
                case GridStringId.MenuColumnSortDescending:
                    return "Сортиране в низходящ ред";
                case GridStringId.MenuColumnClearSorting:
                    return "Изчисти сортирането";
                case GridStringId.MenuColumnGroup:
                    return "Групирай";
                case GridStringId.MenuColumnGroupBox:
                    return "Покажи/Скрий зона за групиране";
                case GridStringId.MenuColumnColumnCustomization:
                    return "Избор на колони";
                case GridStringId.MenuColumnBestFit:
                    return "Оптимална ширина";
                case GridStringId.MenuColumnClearFilter:
                    return "Изчисти филтъра";
                case GridStringId.MenuColumnFilterEditor:
                    return "Редактор на филтър";
                case GridStringId.MenuColumnBestFitAllColumns:
                    return "Оптимална ширина на всички колони";
                case GridStringId.MenuGroupPanelFullExpand:
                    return "Пълно разгъване";
                case GridStringId.MenuGroupPanelFullCollapse:
                    return "Пълно събиране";
                case GridStringId.MenuGroupPanelClearGrouping:
                    return "Изчисти групирането";
                case GridStringId.MenuColumnUnGroup:
                    return "Изчисти групирането за колоната";
                case GridStringId.GridNewRowText:
                    return "Добавяне на нов запис";
                case GridStringId.CardViewNewCard:
                    return "Нова карта";
            }
            return base.GetLocalizedString(id);
        }
    }
    public class DevExPivotBulgarianLocalizer : PivotGridLocalizer
    {
        public override string GetLocalizedString(PivotGridStringId id)
        {
            switch (id)
            {
                case PivotGridStringId.GrandTotal:
                    return "Обща сума";
                case PivotGridStringId.Total:
                    return "Сума";
                case PivotGridStringId.RowArea:
                    return "Редове";
                case PivotGridStringId.ColumnArea:
                    return "Колони";
                case PivotGridStringId.DataArea:
                    return "Данни";
                case PivotGridStringId.FilterArea:
                    return "Полета";
                case PivotGridStringId.DataHeadersCustomization:
                    return "Добави полета за данни тук";
                case PivotGridStringId.RowHeadersCustomization:
                    return "Добави полета за редове тук";
                case PivotGridStringId.ColumnHeadersCustomization:
                    return "Добави полета за колони тук";
                case PivotGridStringId.DataFieldCaption:
                    return "Данни";
                case PivotGridStringId.FilterShowAll:
                    return "Покажи всички";
                case PivotGridStringId.PopupMenuCollapse:
                    return "Събери";
                case PivotGridStringId.PopupMenuCollapseAll:
                    return "Събери  всички";
                case PivotGridStringId.PopupMenuExpand:
                    return "Разгъни";
                case PivotGridStringId.PopupMenuExpandAll:
                    return "Разгъни всички";
                case PivotGridStringId.PopupMenuHideField:
                    return "Скрий полето";
                case PivotGridStringId.PopupMenuRefreshData:
                    return "Опресни данните";
                case PivotGridStringId.PopupMenuShowFieldList:
                    return "Покажи списък с полетата";
                case PivotGridStringId.PopupMenuFieldOrder:
                    return "Ред на полетата";
                case PivotGridStringId.PopupMenuMovetoBeginning:
                    return "Премести в началото";
                case PivotGridStringId.PopupMenuMovetoLeft:
                    return "Премести в ляво";
                case PivotGridStringId.PopupMenuMovetoRight:
                    return "Премести в дясно";
                case PivotGridStringId.PopupMenuMovetoEnd:
                    return "Премести в края";
                case PivotGridStringId.FilterHeadersCustomization:
                    return "Полета";
                case PivotGridStringId.CustomizationFormCaption:
                    return "Списък с полета";
                case PivotGridStringId.CustomizationFormAddTo:
                    return "Добави към";
                case PivotGridStringId.CustomizationFormText:
                    return "Полета";
                case PivotGridStringId.FilterShowBlanks:
                    return "Покажи празните";
            }
            return base.GetLocalizedString(id);
        }
    }
}
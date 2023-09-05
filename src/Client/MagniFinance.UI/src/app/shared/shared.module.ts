import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { TreeTableModule } from 'primeng/treetable';
import { ToolbarModule } from "primeng/toolbar";
import { AccordionModule } from 'primeng/accordion';
import { AutoCompleteModule } from 'primeng/autocomplete';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { ButtonModule } from 'primeng/button';
import { CalendarModule } from 'primeng/calendar';
import { CardModule } from 'primeng/card';
import { CarouselModule } from 'primeng/carousel';
import { CheckboxModule } from 'primeng/checkbox';
import { ChipsModule } from 'primeng/chips';
import { ColorPickerModule } from 'primeng/colorpicker';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { ContextMenuModule } from 'primeng/contextmenu';
import { DataViewModule } from 'primeng/dataview';
import { DialogModule } from 'primeng/dialog';
import { DropdownModule } from 'primeng/dropdown';
import { FieldsetModule } from 'primeng/fieldset';
import { FileUploadModule } from 'primeng/fileupload';
import { GalleriaModule } from 'primeng/galleria';
import { InplaceModule } from 'primeng/inplace';
import { InputMaskModule } from 'primeng/inputmask';
import { InputSwitchModule } from 'primeng/inputswitch';
import { InputTextModule } from 'primeng/inputtext';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { ListboxModule } from 'primeng/listbox';
import { MegaMenuModule } from 'primeng/megamenu';
import { MenuModule } from 'primeng/menu';
import { MenubarModule } from 'primeng/menubar';
import { MessageModule } from 'primeng/message';
import { MessagesModule } from 'primeng/messages';
import { MultiSelectModule } from 'primeng/multiselect';
import { OrganizationChartModule } from 'primeng/organizationchart';
import { OverlayPanelModule } from 'primeng/overlaypanel';
import { PaginatorModule } from 'primeng/paginator';
import { PanelModule } from 'primeng/panel';
import { PanelMenuModule } from 'primeng/panelmenu';
import { PasswordModule } from 'primeng/password';
import { ProgressBarModule } from 'primeng/progressbar';
import { RadioButtonModule } from 'primeng/radiobutton';
import { RatingModule } from 'primeng/rating';
import { ScrollPanelModule } from 'primeng/scrollpanel';
import { SelectButtonModule } from 'primeng/selectbutton';
import { SlideMenuModule } from 'primeng/slidemenu';
import { SliderModule } from 'primeng/slider';
import { SpinnerModule } from 'primeng/spinner';
import { SplitButtonModule } from 'primeng/splitbutton';
import { StepsModule } from 'primeng/steps';
import { TabMenuModule } from 'primeng/tabmenu';
import { TabViewModule } from 'primeng/tabview';
import { TerminalModule } from 'primeng/terminal';
import { TieredMenuModule } from 'primeng/tieredmenu';
import { ToastModule } from 'primeng/toast';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { TooltipModule } from 'primeng/tooltip';
import { TreeModule } from 'primeng/tree';
import { VirtualScrollerModule } from 'primeng/virtualscroller';
import { ProgressSpinnerModule } from 'primeng/progressspinner';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
     // NG Prime Modulse
     AccordionModule, AutoCompleteModule, BreadcrumbModule, ButtonModule, CalendarModule, CardModule,
     CarouselModule, CheckboxModule, ChipsModule, ColorPickerModule,
     ConfirmDialogModule, ContextMenuModule, DataViewModule, DialogModule, DropdownModule,
     FieldsetModule, FileUploadModule, GalleriaModule, InplaceModule,
     InputMaskModule, InputSwitchModule, InputTextareaModule, InputTextModule, ListboxModule,
     MegaMenuModule, MenubarModule, MenuModule, MessageModule, MessagesModule, MultiSelectModule,
    OrganizationChartModule, OverlayPanelModule, PaginatorModule, PanelMenuModule, PanelModule,
     PasswordModule, ProgressBarModule, RadioButtonModule, RatingModule, ScrollPanelModule,
     SelectButtonModule, SlideMenuModule, SliderModule, SpinnerModule, SplitButtonModule, StepsModule, TableModule,
     TabMenuModule, TabViewModule, TerminalModule, TieredMenuModule, ToastModule, ToggleButtonModule, ToolbarModule,
     TooltipModule, TreeModule, TreeTableModule, VirtualScrollerModule, ProgressSpinnerModule
  ],
  exports: [
    FormsModule, 
     // NG Prime Modulse
     AccordionModule, AutoCompleteModule, BreadcrumbModule, ButtonModule, CalendarModule, CardModule,
     CarouselModule, CheckboxModule, ChipsModule, ColorPickerModule,
     ConfirmDialogModule, ContextMenuModule, DataViewModule, DialogModule, DropdownModule,
     FieldsetModule, FileUploadModule, GalleriaModule, InplaceModule,
     InputMaskModule, InputSwitchModule, InputTextareaModule, InputTextModule, ListboxModule,
     MegaMenuModule, MenubarModule, MenuModule, MessageModule, MessagesModule, MultiSelectModule,
     OrganizationChartModule, OverlayPanelModule, PaginatorModule, PanelMenuModule, PanelModule,
     PasswordModule, ProgressBarModule, RadioButtonModule, RatingModule, ScrollPanelModule,
     SelectButtonModule, SlideMenuModule, SliderModule, SpinnerModule, SplitButtonModule, StepsModule, TableModule,
     TabMenuModule, TabViewModule, TerminalModule, TieredMenuModule, ToastModule, ToggleButtonModule, ToolbarModule,
     TooltipModule, TreeModule, TreeTableModule, VirtualScrollerModule, ProgressSpinnerModule
  ]
})
export class SharedModule { }

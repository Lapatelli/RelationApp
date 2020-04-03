import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { RelationModule } from './relation/relation.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DialogModule, DialogService, DropdownModule, DynamicDialogModule, OverlayPanelModule } from 'primeng';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RelationModule,
    HttpClientModule,
    FormsModule,
    DynamicDialogModule,
    DialogModule,
    DropdownModule,
    OverlayPanelModule
  ],
  providers: [DialogService],
  bootstrap: [AppComponent]
})
export class AppModule { }

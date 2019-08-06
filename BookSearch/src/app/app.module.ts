import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { ContentComponent } from './search/content/content.component';


import { InputTextModule } from 'primeng/inputtext';
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { SearchComponent } from './search/search.component';
import { ToolbarModule } from 'primeng/toolbar';
import { DataViewModule } from 'primeng/dataview';
import { PanelModule } from 'primeng/panel';
import { DialogModule } from 'primeng/dialog';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SearchComponent,
    ContentComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    InputTextModule,
    FormsModule,
    ButtonModule,
    ToastModule,
    ToolbarModule,
    DataViewModule,
    PanelModule,
    DialogModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

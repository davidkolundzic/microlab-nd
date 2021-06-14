import { BrowserModule } from '@angular/platform-browser';
import  { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { HttpService} from './http.service';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { NotesComponent } from './notes/notes.component';
// import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BlockUIService } from './block-ui.service';
import { RemindersComponent } from './reminders/reminders.component';
import { AppRoutingModule } from './app-routing.module';
import { NavMenuLeftComponent } from './nav-menu-left/nav-menu-left.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    FetchDataComponent,
    NotesComponent,
    RemindersComponent,
    NavMenuLeftComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    
    AppRoutingModule
  ],
  providers: [ HttpService, BlockUIService],
  bootstrap: [AppComponent]
})
export class AppModule { }

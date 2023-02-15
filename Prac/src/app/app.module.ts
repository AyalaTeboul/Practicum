import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { InstructionsComponent } from './instructions/instructions.component';
import { AddPersonComponent } from './add-person/add-person.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatSelectModule} from '@angular/material/select';
import {MatInputModule} from '@angular/material/input';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';
import {MatRadioModule} from '@angular/material/radio' 
import {MatCardModule} from '@angular/material/card';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon'
import { HttpClientModule } from '@angular/common/http';
import { FinishComponent } from './finish/finish.component';
@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    InstructionsComponent,
    AddPersonComponent,
    FinishComponent,
    
  ],
  imports: [
    BrowserModule, FormsModule,
    AppRoutingModule,HttpClientModule,
    BrowserAnimationsModule,
     MatFormFieldModule,
     MatSelectModule,
     MatInputModule,
     FormsModule,
     MatSlideToggleModule,
     MatRadioModule,
     ReactiveFormsModule,
     MatCardModule,
     MatDatepickerModule,
     MatNativeDateModule,
     MatButtonModule,
     MatToolbarModule,
     MatIconModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule { }

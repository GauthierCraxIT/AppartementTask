import { AuthInterceptor } from './auth.interceptor';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HomeComponent } from './home/home.component';
import { ReactiveFormsModule } from '@angular/forms';
import { AuthService } from './auth.service';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { AuthjwtService } from './authjwt.service';
import { CreateComponent } from './cms/create/create.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatRadioModule } from '@angular/material/radio';
import { MatListModule } from '@angular/material/list';
import { DragDropModule } from '@angular/cdk/drag-drop'
import { ResidenceService } from './residence.service';
import { DetailsComponent } from './home/details/details.component';
import { CmsComponent } from './cms/cms.component';
import { EditComponent } from './cms/edit/edit.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    CreateComponent,
    DetailsComponent,
    CmsComponent,
    EditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatIconModule,
    MatListModule,
    MatFormFieldModule,
    MatInputModule,
    DragDropModule,
    MatCheckboxModule,
    MatTabsModule,
    MatRadioModule,
    MatCardModule,
    MatToolbarModule,
    MatButtonModule
  ],
  providers: [AuthService, AuthjwtService, ResidenceService, { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }

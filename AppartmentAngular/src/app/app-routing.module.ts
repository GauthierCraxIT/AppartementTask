import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CmsComponent } from './cms/cms.component';
import { CreateComponent } from './cms/create/create.component';
import { EditComponent } from './cms/edit/edit.component';
import { DetailsComponent } from './home/details/details.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: "login", component: LoginComponent },
  { path: "register", component: RegisterComponent },
  { path: "home", component: HomeComponent },
  { path: "home/details", component: DetailsComponent },
  {
    path: "cms", component: CmsComponent, children: [
      { path: "create", component: CreateComponent },
      { path: "edit", component: EditComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

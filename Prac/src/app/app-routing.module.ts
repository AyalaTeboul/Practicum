import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddPersonComponent } from './add-person/add-person.component';
import { FinishComponent } from './finish/finish.component';
import { InstructionsComponent } from './instructions/instructions.component';

const routes: Routes = [
  { path: "add", component: AddPersonComponent },
  { path: "instructions", component: InstructionsComponent },
  { path: "finish", component: FinishComponent },
  { path: "", redirectTo: "instructions", pathMatch: "full" },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

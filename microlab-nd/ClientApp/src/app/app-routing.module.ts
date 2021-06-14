import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { FetchDataComponent } from "./fetch-data/fetch-data.component";
import { NotesComponent } from "./notes/notes.component";
import { RemindersComponent } from './reminders/reminders.component';


const routes: Routes = [
  { path: "", component: HomeComponent, pathMatch: "full" },
  { path: "fetch-data", component: FetchDataComponent },
  { path: "app", component: NotesComponent },
  { path: "remaind", component: RemindersComponent}
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}

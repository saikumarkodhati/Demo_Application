import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { searchbookroute } from "../routing/searchbookroute";
import { GridUIModule } from "../utilites/grid-ui/grid-ui.module";
import { SearchBookComponent } from "./searchbook.component";
import { HttpClientModule } from "@angular/common/http";

@NgModule({
    declarations:[
        SearchBookComponent
    ],
    imports:[
        CommonModule,
        FormsModule,
        RouterModule.forChild(searchbookroute),
        GridUIModule,
        HttpClientModule
    ],
    providers: [],
    bootstrap: [SearchBookComponent]
  })
  export class SearchBookModule { }













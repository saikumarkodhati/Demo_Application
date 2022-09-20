import { HomeComponent } from "../home/home.component";
import { LoginComponent } from "../login/login.component";
import { GridUIModule } from "../utilites/grid-ui/grid-ui.module";


export const Mainroutes = [
    { path: '', component: HomeComponent },
    { path:'login',component:LoginComponent},
    { path: 'createbook', loadChildren: () => import('../createbook/createbook.module').then(m => m.CreatebookModule) },
    { path: 'searchbook', loadChildren: () => import('../searchbook/searchbook.module').then(m => m.SearchBookModule) },
    { path: 'register', loadChildren: () => import('../utilites/grid-ui/grid-ui.module').then(m => m.GridUIModule) },
    { path: 'home', component: HomeComponent },
];
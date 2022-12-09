
import {HttpService} from "../services/http.service";

/*@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']*/
/*})*/
export class AppComponent {
  formModel : Option = new Option(); // Sets formModel = to the Option class

  constructor(private http: HttpService) {
  }



  async ngOnInit(){
    const options = await this.http.getOptions();
    console.log(options)
  }


}


// is in change of the 3 txt fields information storing when creating or edit
class OptionDto {
  name: string = "";
}
// Sets the id when it is needed
class Option extends OptionDto{
  id: number = 0;
}

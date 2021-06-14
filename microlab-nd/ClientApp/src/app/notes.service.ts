import { Injectable } from '@angular/core';
import { HttpService } from './http.service';
import { HttpErrorResponse} from '@angular/common/http';
import { Observable } from 'rxjs';
import { Note } from './model/note-model';

@Injectable({
  providedIn: 'root'
})
export class NotesService {
  api='api/notes';
    constructor(private httpService: HttpService) {

   }

   createUser():Observable<any>{
     return this.httpService.post(this.api + '/create');
   }
   createNote(note:Note): Observable<any>{
     return this.httpService.post(this.api +  "/createNote", note);
   }

   updateNote(note:Note): Observable<any>{
     return this.httpService.post(this.api +  "/updateNote", note);
   }
   


   getNotes(id:number):Observable<any>{
     return this.httpService.get(this.api + "/getNotes?id=" + id);
   }
   removeNote(id:number): Observable<any>{
     return this.httpService.get(this.api + "/removeNote?id=" + id); 
   }
   sendEmail(note: Note): Observable<any>{
     console.log("service send mail");
    return this.httpService.post(this.api + "/sendMail", note); 
   }
}

import { Component, Inject, OnInit, TemplateRef } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { NgForm } from "@angular/forms";
import { Note, REMAINDERS, USER } from "../model/note-model";
import { BsModalService, BsModalRef } from "ngx-bootstrap/modal";
import {NotesService} from "../notes.service";

@Component({
  selector: "app-notes",
  templateUrl: "./notes.component.html",
  styleUrls: ["./notes.component.css"],
})
export class NotesComponent implements OnInit {
  // Test user data
  user = USER;
  result? = "";
  reminders = REMAINDERS;
  note: Note = new Note();
  notes: Array<Note> = [];
  ddlValid: boolean;
  mouseoverSubmit: boolean;

  copyNote: Note;
  editNote: Note;
  editNoteIndex: number;

  modalRef: BsModalRef;
  config = {
    ignoreBackdropClick: true,
  };

  constructor(
    private http: HttpClient,
    @Inject("BASE_URL") baseUrl: string,
    private modalService: BsModalService,
    private notesService: NotesService
  ) {
    
  }

  ngOnInit() {
    this.note.reminder = null;
    this.notesService.getNotes(this.user.Id).subscribe(
      res => {
        console.log(res);
        this.notes = res;
      },
      err=> {
        console.log(err)
      }
    )
  }

  onSubmit(loginform: NgForm) {

    this.note.contactId = this.user.Id;
    this.note.id = 0;   
    
    this.notesService.createNote(this.note).subscribe(
      res =>{
        const copynote = {...this.note}
        this.notes.push(copynote);
        
        loginform.resetForm(this.note);
        this.clearNote();        
      },
      err => {
        console.log(err)
      }
    )
  }
 
  onDelete(index) {
    if (this.notes[index].id || this.notes[index].id > 0) {
      this.notesService.removeNote(index).subscribe(
        res=> {
          this.notes.splice(index, 1)
        }
      ) ,
      err=> {
        console.error(err)
      } 
      
    } else {
      this.notes.splice(index, 1);
    }
    
  }
  clearNote() {
    this.note = new Note();
    this.note.noteDate = null;
    this.note.description = "";
    this.note.reminder = null;
    this.ddlValid = false;
  }
  selectRemainder(event) {
    this.ddlValid = this.isddlValid();
  }
  isddlValid() {
    return this.note.reminder >= 0;
  }
  openModal(template: TemplateRef<any>, index) {
    this.copyNote = { ...this.notes[index] };
    this.editNote = this.notes[index];
    this.editNoteIndex = index;
    this.modalRef = this.modalService.show(template, this.config);
  }
  confirm(): void {
    this.modalRef.hide();
  }
  decline(): void {
    this.notes[this.editNoteIndex] = this.copyNote;
    this.modalRef.hide();
  }
}

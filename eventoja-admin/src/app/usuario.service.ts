import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Usuario } from 'src/Models/Usuario';

@Injectable({
  providedIn: 'root',
})
export class UsuarioService {
  public usuarioLogado: Usuario  = null as any;
  constructor(private http: HttpClient) {
    const usuario = localStorage.getItem('usuario');

  }

  async  login(usuario:string,senha:string) {
   const usuarioApi = this.http
   .post<Usuario>('http://localhost:5153/api/Usuario/login',{
     login:usuario,
     senha:senha,
     nome:"",
     saldoBancario:0

   } as Usuario)
   .toPromise();
   if (usuarioApi == null ) return;
   this.usuarioLogado =usuarioApi as any;
   localStorage.setItem('usuario',JSON.stringify(this.usuarioLogado))
   return usuarioApi

  }
  async BuscarTodos() {
    return this.http
      .get<Usuario[]>('http://localhost:5153/api/Usuario/buscar-todos')
      .toPromise();
  }
  async Deslogar() {
    localStorage.clear();
    this.usuarioLogado = null as any;
  }
}

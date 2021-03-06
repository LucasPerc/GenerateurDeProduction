function ArriveePredefinie(ID,posX,posY,firstElement,Sequence,objS,linkID) {

    this.ID=ID;
    this.x=posX;
    this.y=posY;
    this.Sequence = Sequence;
    this.objS=objS;
    this.linkID=linkID;
    this.seqID = 0;
    this.SequenceStarted=false;
    this.nbPaquets=0;
}

ArriveePredefinie.prototype.draw = function(){
  ctx.fillStyle = 'blue';
  ctx.fillRect(this.x-20, this.y, 30, 10);  
  ctx.fillRect(this.x, this.y-20, 10, 30);
  ctx.fillRect(this.x-20, this.y-20, 30, 10);
  ctx.fillRect(this.x-20, this.y-20, 10, 30); 
  if(!this.SequenceStarted) { this.StartSequence(); };
}
ArriveePredefinie.prototype.SetSuiv = function(obj){
  this.objS = obj;
}
ArriveePredefinie.prototype.SetLinkId = function(id){
  this.linkID=id;
}

ArriveePredefinie.prototype.StartSequence = function(){
  this.nbPaquets=1;
  this.SequenceStarted=true;
  while(this.seqID<this.Sequence.length && this.Sequence[this.seqID]===this.Sequence[this.seqID+1])
  {
    this.seqID+=1;
    this.nbPaquets+=1;
  }
  if(this.seqID-this.nbPaquets>=0)
  {
    var t=this.Sequence[this.seqID-this.nbPaquets]*1000;
  }
  else
  {
    var t=0;
  }
  
  setTimeout(this.CreateRessource.bind(this),this.Sequence[this.seqID]*1000-t);
}
  
ArriveePredefinie.prototype.CreateRessource = function()
{
  if(this.objS!=null)
  {
    if(this.nbPaquets==1)
    {
      this.objS.ProductArrive(new Ressource(this.objS.x,this.objS.y),this.linkID);
    }
    else
    {
      this.objS.ProductArrive(new Paquet(this.objS.x,this.objS.y,this.nbPaquets),this.linkID);       
    }
  }

  this.seqID+=1;
  if(this.seqID<this.Sequence.length)
  {
    this.StartSequence();
  }
}
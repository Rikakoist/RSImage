PRO CreateROI_PolyGon,imagefile,txtfilepath,resultfile


  COMPILE_OPT idl2
  ENVI,/restore_base_save_files
  ENVI_BATCH_INIT,log_file='batch.text'
  
  ; Ӱ�����Ϣ
  ;imagefile='D:\SPOT\miyun_huairou\huairou.tif'
  ENVI_OPEN_FILE,imagefile,r_fid=fid
  IF(fid EQ -1) THEN BEGIN
  
    void=DIALOG_MESSAGE('�Ҳ���Ӱ���ļ�')
    RETURN
  ENDIF
  ENVI_FILE_QUERY,fid,dims=dims,nl=nl,ns=ns,nb=nb
  
  ;txtfilepath='C:\Users\zhzhx\Documents\Visual Studio 2010\Projects\supervised_test\supervised_test\bin\Debug\temp.txt'
  
  IF FILE_TEST(txtfilepath) THEN BEGIN
    nlines=FILE_LINES(txtfilepath)
    ;  roi_ids=intarr(n_elements(nlines))
    temp=''
    
    ;���ļ�
    OPENR,lun,txtfilepath,/get_lun
    
    WHILE(~EOF(lun)) DO BEGIN
    
      READF,lun,temp
      ;PRINT,temp
      ;��ȡÿһ��
      line=strsplit(temp,/extract)
      ;��ȡ������������var[1]Ϊx���꣬
      var=strsplit(line,':',/extract)
      
      ;�������ƺ���ɫ
      color  =FIX(var[2])
      class_name =var[3]
      ;x ,y���� �ֳ�ÿ�������
      varx=strsplit(var[0],'*',/extract)
      vary=strsplit(var[1],'*',/extract)
      varxyCount=N_ELEMENTS(varx)
      ;x,y �����еĸ��������������ȡ����
      roi_id=ENVI_CREATE_ROI(ns=ns,nl=nl,color=color,name=class_name)
      FOR i=0,varxyCount-1 DO BEGIN
        varxOfOnePG=varx[i]
        varxOfOnePg=strsplit(varxOfOnePG,',',/extract)
        varyOfOnePg=vary[i]
        varyOfOnePg=strsplit(varyOfOnePG,',',/extract)
        ;x ���꣬y����
        xvalue_arr=FLOAT(varxOfOnePG)
        yvalue_arr=FLOAT(varyOfOnePg)
        ; ��x��y�������ת����ת��Ϊ�ļ�����
        ENVI_CONVERT_FILE_COORDINATES,fid,xfile,yfile,xvalue_arr,yvalue_arr
        ENVI_DEFINE_ROI, roi_id, /polygon, $
          xpts=xfile, ypts=yfile,/no_update
          
      ENDFOR
    ENDWHILE
    
    ;resultfile='d:\roi.roi'
    ; outname='d:\roi.roi'
    roi_ids=ENVI_GET_ROI_IDS()
    ENVI_SAVE_ROIS,resultfile,roi_ids
  ENDIF

END
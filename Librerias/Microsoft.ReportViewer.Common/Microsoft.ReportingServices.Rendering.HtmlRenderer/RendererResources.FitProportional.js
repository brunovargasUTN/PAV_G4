﻿var Microsoft_ReportingServices_HTMLRenderer_FitProportional=function(){};Microsoft_ReportingServices_HTMLRenderer_FitProportional.prototype={ResizeImage:function(n,t,i){var r,w,a,ut,ft,et,s,h,k,l,v,tt,it,rt;if(n&&(r=n.parentNode,r)){var f=n.width,o=n.height,d=n,u=r,a=!1;r.tagName=="A"&&(r=r.parentNode,u=r),w=Microsoft_ReportingServices_HTMLRenderer_IsStandardsMode(),a=!1,w&&Microsoft_ReportingServices_HTMLRenderer_IsIE()&&!Microsoft_ReportingServices_HTMLRenderer_IsIE8OrLater()&&(a=!0),w&&Microsoft_ReportingServices_HTMLRenderer_IsIE()&&u.getAttribute("alreadyResized")==null&&(u.currentStyle.minWidth&&u.clientWidth>Microsoft_ReportingServices_HTMLRenderer_ConvertToPx(u.currentStyle.minWidth)+1&&(ut=Microsoft_ReportingServices_HTMLRenderer_SubtractHorizontalBordersPaddings(u),u.style.minWidth=ut),a&&(u.currentStyle.width&&u.clientWidth>Microsoft_ReportingServices_HTMLRenderer_ConvertToPx(u.currentStyle.width)+1&&(ft=Microsoft_ReportingServices_HTMLRenderer_SubtractHorizontalBordersPaddings(u),u.style.width=ft),u.currentStyle.height&&u.clientHeight>Microsoft_ReportingServices_HTMLRenderer_ConvertToPx(u.currentStyle.height)+1&&(et=Microsoft_ReportingServices_HTMLRenderer_SubtractVerticalBordersPaddings(u),u.style.height=et)),u.setAttribute("alreadyResized","true"));var g=1,b=!1,vt=!1,e=1,nt=!1;if(r.tagName=="DIV"&&r.getAttribute("imgConFitProp")&&(d=r,o=parseInt(r.style.height),f=parseInt(r.style.width),r=r.parentNode,g=0,b=!0,w&&Microsoft_ReportingServices_HTMLRenderer_IsIE()&&a&&(d.style.position!="absolute"&&(d.style.position="absolute"),e=Microsoft_ReportingServices_HTMLRenderer_CalculateZoom(i),r.getAttribute("origHeight")?o=r.getAttribute("origHeight"):r.setAttribute("origHeight",o),r.getAttribute("origWidth")?f=r.getAttribute("origWidth"):r.setAttribute("origWidth",f),nt=!0)),n.width!=0&&n.height!=0&&r){s=n.height,h=n.width,n.naturalHeight?(s=n.naturalHeight,h=n.naturalWidth,b||(o=s,f=h)):n.width!=1||n.height!=1||b||(k=new Image,k.src=n.src,s=k.height,h=k.width,o=s,f=h),nt&&(n.getAttribute("origHeight")?s=n.getAttribute("origHeight"):n.setAttribute("origHeight",s),n.getAttribute("origWidth")?h=n.getAttribute("origWidth"):n.setAttribute("origWidth",h)),l=r.clientHeight,v=r.clientWidth,n.clientHeight==r.clientHeight&&r.parentNode&&r.parentNode.clientHeight>=n.clientHeight&&(l=r.parentNode.clientHeight,r.parentNode.nodeName=="TD"&&r.parentNode.parentNode.clientHeight>l&&(l=r.parentNode.parentNode.clientHeight),v=r.parentNode.clientWidth);var lt=(l+g-n.pv)/o,at=(v+g-n.ph)/f,c=Math.min(at,lt),y=s*c*e,p=h*c*e;if(b){y>0&&(n.height=y),f&&p>0&&(n.width=p),o>0&&c>0&&(u.style.height=o*c*e+"px"),f>0&&c>0&&(u.style.width=f*c*e+"px");var ot=parseInt(n.style.left),st=parseInt(n.style.top),ht=0,ct=0;nt&&(tt=Microsoft_ReportingServices_HTMLRenderer_CalculateOffset(t,r),ct=tt.left,ht=tt.top,n.getAttribute("origTop")?st=parseInt(n.getAttribute("origTop")):n.setAttribute("origTop",parseInt(n.style.top)),n.getAttribute("origLeft")?ot=parseInt(n.getAttribute("origLeft")):n.setAttribute("origLeft",parseInt(n.style.left)),n.style.top=st*e+"px",n.style.left=ot*e+"px"),a||(u.style.position="relative"),it=parseInt(n.style.left),rt=parseInt(n.style.top),it!=null&&(n.style.left=parseInt(it*c)+"px"),rt!=null&&(n.style.top=parseInt(rt*c)+"px"),u.style.left=ct*e+"px",u.style.top=ht*e+"px"}else y>l&&(y=l),p>v&&(p=v),n.height=y,f&&(n.width=p)}}},ResizeImages:function(n,t){for(var i=document.getElementById(n),f,u,r;i;){if(i.tagName=="DIV")for(f=i.getElementsByTagName("IMG"),u=0;u<f.length;u++)r=f[u],r.fitproportional&&r.complete&&!r.errored&&this.ResizeImage(r,i,t);i=i.nextSibling}},PollResizeImages:function(n){var f=document.getElementById(n),r,i,u;if(f){for(r=f.getElementsByTagName("IMG"),i=0;i<r.length;i++)if(u=r[i],!u.complete&&!u.errored){setTimeout("this.PollResizeImages("+escape(n)+","+escape(n)+")",250);return}this.ResizeImages(n)}}};
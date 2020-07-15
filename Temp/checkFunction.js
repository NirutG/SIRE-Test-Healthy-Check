function setTargetWindow(form) {
    for (i = 0; i < form.device.length; i++) {
      if (form.device[i].checked) {
        form.target = (form.device[i].value == 'disk') ? '_top' : '_blank';
        break;
      }
    }
    return true;
  }

  function getCookieValue(name) {
    var value = "";
    var cookie = document.cookie + ";";
    var index = cookie.indexOf(name);
    if (index != -1) {
      var beginIndex = cookie.indexOf("=", index);
      var endIndex = cookie.indexOf(";", index);
      if (beginIndex != -1 && endIndex != -1 && beginIndex < endIndex) {
        value = cookie.substring(beginIndex + 1, endIndex);		// must not decode because JavaScript does not have the compatible method with Java
      }
    }
    return value;
  }

  function applyCookies() {
    // location
    var location = getCookieValue("com-location");
    document.main.location.selectedIndex = location;

    // mtype
    var mtype = getCookieValue("com-mtype");
    if (mtype != "") {
      var numMtype = document.main.mtype.length;
      for (var i = 0; i < numMtype; i++) {
        if (document.main.mtype.options[i].value == mtype) {
          document.main.mtype.selectedIndex = i;
          break;
        }
      }
    }
    
    // modelid
    var modelid = getCookieValue("com-modelid");
    mTypeChanged(modelid);
    
    // process
    var process = getCookieValue("com-process");
    if (process != "") {
      var numProcess = document.main.process.length;
      for (i = 0; i < numProcess; i++) {
        if (document.main.process.options[i].value == process) {
          document.main.process.selectedIndex = i;
          break;
        }
      }
    }

    // options
    if (getCookieValue("firstcycle") == "true") {
      document.main.firstcycle.checked = "true";
    }
    if (getCookieValue("primeparts") == "true") {
      document.main.primeparts.checked = "true";
    }
    if (getCookieValue("exretest") == "true") {
      document.main.exretest.checked = "true";
    }
    if (getCookieValue("extrial") == "true") {
      document.main.extrial.checked = "true";
    }
    if (getCookieValue("exshipret") == "true") {
      document.main.exshipret.checked = "true";
    }
  }

  function toStandardMode() {
    toggleDisplay("toggle-std", true);
    toggleDisplay("toggle-adv", false);
    disableAdvancedFields(true);
  }

  function toAdvancedMode() {
    toggleDisplay("toggle-std", false);
    toggleDisplay("toggle-adv", true);
    disableAdvancedFields(false);
  }

  function disableAdvancedFields(disabled) {
    // for firefox
    for (var i = 0; i < document.main.scanmodesub.length; i++) {
//      document.main.scanmodesub[i].disabled = disabled;
      if (disabled || document.main.datekey[1].checked || document.main.scanmode[1].checked) {
        document.main.scanmodesub[i].disabled = true;
      } else {
        document.main.scanmodesub[i].disabled = false;
      }
    }
    for (var i = 8; i < document.main.pfcode.length; i++) {
      document.main.pfcode[i].disabled = disabled;
    }
    document.main.expfcode.disabled = disabled;
    for (var i = 8; i < document.main.hddtrial.length; i++) {
      document.main.hddtrial[i].disabled = disabled;
    }
    for (var i = 8; i < document.main.hsatrial.length; i++) {
      document.main.hsatrial[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.mfgid.length; i++) {
      document.main.mfgid[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.testerid.length; i++) {
      document.main.testerid[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.cellid.length; i++) {
      document.main.cellid[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.testertype.length; i++) {
      document.main.testertype[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.testcode.length; i++) {
      document.main.testcode[i].disabled = disabled;
    }
    document.main.partid_spdl.disabled = disabled;
    document.main.partid_disk.disabled = disabled;
    document.main.partid_hsa.disabled = disabled;
    document.main.partid_card.disabled = disabled;
    document.main.partid_hgau.disabled = disabled;
    document.main.partid_hgad.disabled = disabled;
    document.main.partid_sldu.disabled = disabled;
    document.main.partid_sldd.disabled = disabled;
    for (var i = 0; i < document.main.hsapn.length; i++) {
      document.main.hsapn[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.hgapn.length; i++) {
      document.main.hgapn[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.sliderec.length; i++) {
      document.main.sliderec[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.diskpn.length; i++) {
      document.main.diskpn[i].disabled = disabled;
    }
    document.main.cycle.disabled = disabled;
    for (var i = 0; i < document.main.disposition.length; i++) {
      document.main.disposition[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.lineid.length; i++) {
      document.main.lineid[i].disabled = disabled;
    }
    for (var i = 0; i < document.main.teamid.length; i++) {
      document.main.teamid[i].disabled = disabled;
    }
  }

  function toggleDisplay(className, display) {
    var divList = document.getElementsByTagName("div");
    if (divList) {
      if (divList.length) {
        for (var i = 0; i < divList.length; i++) {
          if (divList.item(i).className == className) {
            var style = divList.item(i).style;
            style.display = display ? 'block' : 'none';
          }
        }
      }
    }
    var spanList = document.getElementsByTagName("span");
    if (spanList) {
      if (spanList.length) {
        for (var i = 0; i < spanList.length; i++) {
          if (spanList.item(i).className == className) {
            var style = spanList.item(i).style;
            style.display = display ? 'inline' : 'none';
          }
        }
      }
    }
  }

  function mTypeChanged(selectedModelId) {
    var product = document.main.mtype.options[document.main.mtype.selectedIndex].text.substr(0,3);
    var len = document.main.modelid.length;
    var node = null;
    for (var i = 1; i < len; i++) {
      if (document.main.modelid.options[i].text.lastIndexOf(product, 0) == 0) {
        if (node != null) {
          document.main.modelid.insertBefore(document.main.modelid.options[i], node);
        }
      } else {
        if (node == null) {
          node = document.main.modelid.options[i];
        }
      }
    }

    if (selectedModelId != "" && selectedModelId != document.main.modelid.options[document.main.modelid.selectedIndex].text) {
      for (var i = 0; i < len; i++) {
        if (selectedModelId == document.main.modelid.options[i].text) {
          document.main.modelid.selectedIndex = i;
          break;
        }
      }
    }
  }

  function dateKeyOrScanModeChanged() {
    if (location.href.match(/#ADV$/) != null) {
      if (document.main.scanmode[1].checked) {
        for (var i = 0; i < document.main.scanmodesub.length; i++) {
          document.main.scanmodesub[i].disabled = true;
        }
      } 
      else {
        for (var i = 0; i < document.main.scanmodesub.length; i++) {
          document.main.scanmodesub[i].disabled = false;
        }
        if (document.main.datekey[1].checked) {
          document.main.scanmodesub[1].disabled = true;
        }
      }
    }
  }

  function formReset() {
    document.main.datekey[0].checked = true;
    document.main.scanmode[1].checked = true;
    dateKeyOrScanModeChanged();
    return true;
  }

  function showPopup(idName) {
    target = document.getElementById(idName);
    target.style.visibility = "visible";
  }

  function hidePopup(idName) {
    target = document.getElementById(idName);
    target.style.visibility = "hidden";
  }

  



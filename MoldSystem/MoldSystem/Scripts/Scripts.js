var callbackHelper = (function () {
    var callbackControlQueue = [],
        currentCallbackControl = null;

    function doCallback(callbackControl, args, sender) {
        if (!currentCallbackControl) {
            currentCallbackControl = callbackControl;
            if (typeof (detailsCallbackPanel) !== "undefined" && callbackControl == mainCallbackPanel)
                detailsCallbackPanel.cpSkipUpdateDetails = true;
            callbackControl.EndCallback.RemoveHandler(onEndCallback);
            callbackControl.EndCallback.AddHandler(onEndCallback);
            callbackControl.PerformCallback(args);
        } else
            placeInQueue(callbackControl, args, getSenderId(sender));
    };
    function getSenderId(senderObject) {
        if (senderObject.constructor === String)
            return senderObject;
        return senderObject.name || senderObject.id;
    };
    function placeInQueue(callbackControl, args, sender) {
        var queue = callbackControlQueue;
        for (var i = 0; i < queue.length; i++) {
            if (queue[i].control == callbackControl && queue[i].sender == sender) {
                queue[i].args = args;
                return;
            }
        }
        queue.push({ control: callbackControl, args: args, sender: sender });
    };
    function doEndCallback(callbackControl) {
        currentCallbackControl = null;
        var queuedPanel = callbackControlQueue.shift();
        if (queuedPanel)
            doCallback(queuedPanel.control, queuedPanel.args, queuedPanel.sender);
    };
    function onEndCallback(sender) {
        sender.EndCallback.RemoveHandler(onEndCallback);
        currentCallbackControl = null;
        var queuedPanel = callbackControlQueue.shift();
        if (queuedPanel)
            doCallback(queuedPanel.control, queuedPanel.args, queuedPanel.sender);
    }
    return {
        DoCallback: doCallback,
        EndCallback: doEndCallback
    };
})();

function mainCallbackPanel_EndCallback(s, e) {
 
}

function serializeArgs(args) {
    var result = [];
    for (var i = 0; i < args.length; i++) {
        var value = args[i] ? args[i].toString() : "";
        result.push(value.length);
        result.push("|");
        result.push(value);
    }
    return result.join("");
}

function showClearedPopup(popup) {
    popup.Show();
    ASPxClientEdit.ClearEditorsInContainer(document.getElementById("EditFormsContainer"));
};

var delsrc;

function gridDeleteButton_Click(e) {
    delsrc = ASPxClientUtils.GetEventSource(e);
    ShowDeletePopup();
};

function saveEditForm(popup, args, isDetail) {
    if (!ASPxClientEdit.ValidateEditorsInContainer(popup.GetMainElement()))
        return;
    popup.Hide();
    var callbackArgs = ["SaveEditForm", popup.cpEditFormName, args];
    var panel = isDetail ? detailsCallbackPanel : mainCallbackPanel;
    callbackHelper.DoCallback(panel, serializeArgs(callbackArgs), popup);
};

function cancelEditForm(popup, args, isDetail) {
    var callbackArgs = ["CancelEditForm", popup.cpEditFormName, args];
    var panel = isDetail ? detailsCallbackPanel : mainCallbackPanel;
    callbackHelper.DoCallback(panel, serializeArgs(callbackArgs), popup);
};

function ShowDeletePopup() {
    popupControl.Show();
    btnYes.Focus();
}

function btnYes_Click(s, e) {
    ClosePopup(true);
}

function btnNo_Click(s, e) {
    ClosePopup(false);
}

function ClosePopup(result) {
    popupControl.Hide();
    if (result) {
        var callbackArgs = ["DeleteEntry", delsrc.id];
        callbackHelper.DoCallback(mainCallbackPanel, serializeArgs(callbackArgs), delsrc);
    }
}

function numeric_keypress(s, e) {
    if (e.htmlEvent.keyCode >= 48 && e.htmlEvent.keyCode <= 57) {
        // number
    }
    else if (e.htmlEvent.keyCode >= 96 && e.htmlEvent.keyCode <= 105) {
        // number in num pad
    }
    else if (e.htmlEvent.keyCode == 8) {
        // backspace
    }
    else if (e.htmlEvent.keyCode == 46) {
        // del
    }
    else if (e.htmlEvent.keyCode >= 37 && e.htmlEvent.keyCode <= 40) {
        // arrow
    }
    else {
        ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);
    }
}
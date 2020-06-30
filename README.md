# HueControlExample

This application contains and console and a WPF application to control Hue lights in an apartment. The WPF app is connecting to a SignalR server which will send cues. TBD on cue structure, etc. The app key and name are hardcoded for now. Eventually, this app is to be used by LD's controlling zoom-type bands/orchastras. This application is paired up with the ASP.Net Core app in this repo https://github.com/olaafrossi/HueSignalRServerExample. This web app sends the cues to the connected clients, which in turn runs controls the Hue lights on the local network. 

using System;

namespace NetAcademia_Command
{
    public class ParancsFeldolgozo
    {
        string[] Parancsok = new string[]
        {
            MagicValues.CommandTextNew,
            MagicValues.CommandTextModify,
            MagicValues.CommandTextDelete
        };
        public string Vegrehajtas(string[] args)
        {
            var parancsSzoveg = args[0];

            //Ellenorzom h a parancs ertelmes-e
            //ha igen, vegrehajtom
            switch (parancsSzoveg)
            {
                case MagicValues.CommandTextNew:
                    return New();
                case MagicValues.CommandTextModify:
                    return Modify(args[1]);
                case MagicValues.CommandTextDelete:
                    return Delete(args[1]);
                default:
                    return MagicValues.CommandResponseInvalid;
            }
        }

        private string Delete(string parameter)
        {
            return string.Format(MagicValues.CommandResponseDelete, parameter);
        }

        private string Modify(string parameter)
        {
            return string.Format(MagicValues.CommandResponseModify, parameter);
        }

        private string New()
        {
            return MagicValues.CommandResponseNew;
        }
    }
}